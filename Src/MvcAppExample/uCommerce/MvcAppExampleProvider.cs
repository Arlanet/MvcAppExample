using System.Collections.Generic;
using UCommerce.Tree;
using UCommerce.Tree.Impl;

namespace MvcAppExample.uCommerce
{
    public class MvcAppExampleProvider : ITreeContentProvider
    {
        public IList<ITreeNodeContent> GetChildren(string nodeType, string id)
        {
            if (nodeType.Equals("apps"))
            {
                return GetRoot();
            }

            if (nodeType.Equals("mvcappexample"))
            {
                return GetChildren();
            }

            return null;
        }

        private List<ITreeNodeContent> GetRoot()
        {
            return new List<ITreeNodeContent>
            {
                new TreeNodeContent("mvcappexample", -1)
                {
                    Name = "Mvc App Examples",
                    HasChildren = true,
                    Icon = "installed_apps.png"
                }
            };
        }

        private List<ITreeNodeContent> GetChildren()
        {
            return new List<ITreeNodeContent>
            {
                new TreeNodeContent("mvcexample", -1)
                {
                    Name = "Mvc Example",
                    HasChildren = false,
                    Action = "/MvcApps/MvcAppExample/Example",
                    Icon = "appsIcon.png"
                },
                new TreeNodeContent("mvctabexample", -1)
                {
                    Name = "Mvc Tab Example",
                    HasChildren = false,
                    Action = "/MvcApps/MvcAppExample/TabExample",
                    Icon = "appsIcon.png"
                },
                new TreeNodeContent("aspnetexample", -1)
                {
                    Name = "WebForms Example",
                    HasChildren = false,
                    Action = "/Apps/MvcAppExample/WebForms/WebFormsPage.aspx",
                    Icon = "appsIcon.png"
                }
            };
        } 

        public bool Supports(string nodeType)
        {
            return nodeType.Equals("apps") || nodeType.Equals("mvcappexample");
        }
    }
}
