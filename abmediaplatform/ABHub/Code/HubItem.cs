

namespace ABHub.Code
{
    /// <summary>
    /// A Simple record that represents a simple list item.
    public record HubItem
    {
        /// <summary>
        /// Default Constuctor 
        /// </summary>
        public HubItem()
        {
            //Do Nothing 
        }
        /// <summary>
        /// Constructor takes a name value 
        /// </summary>
        /// <param name="_name">Name of Item</param>
        public HubItem(string _name)
        {
            Name = _name;
        }

        /// <summary>
        /// Get the Item Name
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Return the Name of the Item 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
