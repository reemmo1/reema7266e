using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace reema7266e
{

        public partial class SiteMaster : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                  
                    HideMenuItemForRole("Admin", "admin");
                    HideMenuItemForRole("Vulnerabilities", "vulnerabilityUser");
                    HideMenuItemForRole("About Us", "guest");
                }
            }

            private void HideMenuItemForRole(string menuItemText, string roleName)
            {
               
                if (!Roles.IsUserInRole(roleName))
                {
                  
                    MenuItemCollection menuItems = NavigationMenu.Items;
                    MenuItem itemToRemove = null;

              
                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Text == menuItemText)
                        {
                            itemToRemove = menuItem;
                            break;
                        }
                    }

               
                    if (itemToRemove != null)
                    {
                        menuItems.Remove(itemToRemove);
                    }
                }
            }

       
            protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
            {
              
            }
        }
    }