﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("EFTestDatabaseModel", "FK_OrderDetails_Orders", "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(EFExtensions.EFWRappableFields.EFTests.Order), "OrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(EFExtensions.EFWRappableFields.EFTests.OrderDetail), true)]
[assembly: EdmRelationshipAttribute("EFTestDatabaseModel", "FK_OrderDetails_Products", "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(EFExtensions.EFWRappableFields.EFTests.Product), "OrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(EFExtensions.EFWRappableFields.EFTests.OrderDetail), true)]
[assembly: EdmRelationshipAttribute("EFTestDatabaseModel", "ProductCategories", "Categories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(EFExtensions.EFWRappableFields.EFTests.Category), "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(EFExtensions.EFWRappableFields.EFTests.Product))]

#endregion

namespace EFExtensions.EFWRappableFields.EFTests
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class EFTestDatabaseEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new EFTestDatabaseEntities object using the connection string found in the 'EFTestDatabaseEntities' section of the application configuration file.
        /// </summary>
        public EFTestDatabaseEntities() : base("name=EFTestDatabaseEntities", "EFTestDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EFTestDatabaseEntities object.
        /// </summary>
        public EFTestDatabaseEntities(string connectionString) : base(connectionString, "EFTestDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EFTestDatabaseEntities object.
        /// </summary>
        public EFTestDatabaseEntities(EntityConnection connection) : base(connection, "EFTestDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Category> Categories
        {
            get
            {
                if ((_Categories == null))
                {
                    _Categories = base.CreateObjectSet<Category>("Categories");
                }
                return _Categories;
            }
        }
        private ObjectSet<Category> _Categories;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<OrderDetail> OrderDetails
        {
            get
            {
                if ((_OrderDetails == null))
                {
                    _OrderDetails = base.CreateObjectSet<OrderDetail>("OrderDetails");
                }
                return _OrderDetails;
            }
        }
        private ObjectSet<OrderDetail> _OrderDetails;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Product> Products
        {
            get
            {
                if ((_Products == null))
                {
                    _Products = base.CreateObjectSet<Product>("Products");
                }
                return _Products;
            }
        }
        private ObjectSet<Product> _Products;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Categories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCategories(Category category)
        {
            base.AddObject("Categories", category);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the OrderDetails EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrderDetails(OrderDetail orderDetail)
        {
            base.AddObject("OrderDetails", orderDetail);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Orders EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Products EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProducts(Product product)
        {
            base.AddObject("Products", product);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EFTestDatabaseModel", Name="Category")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Category : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Category object.
        /// </summary>
        /// <param name="identifier">Initial value of the Identifier property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static Category CreateCategory(global::System.Int32 identifier, global::System.String name, global::System.String description)
        {
            Category category = new Category();
            category.Identifier = identifier;
            category.Name = name;
            category.Description = description;
            return category;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                if (_Identifier != value)
                {
                    OnIdentifierChanging(value);
                    ReportPropertyChanging("Identifier");
                    _Identifier = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Identifier");
                    OnIdentifierChanged();
                }
            }
        }
        private global::System.Int32 _Identifier;
        partial void OnIdentifierChanging(global::System.Int32 value);
        partial void OnIdentifierChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "ProductCategories", "Products")]
        private EntityCollection<Product> DbProducts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Product>("EFTestDatabaseModel.ProductCategories", "Products");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Product>("EFTestDatabaseModel.ProductCategories", "Products", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EFTestDatabaseModel", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="identifier">Initial value of the Identifier property.</param>
        /// <param name="occurance">Initial value of the Occurance property.</param>
        public static Order CreateOrder(global::System.Int32 identifier, global::System.DateTime occurance)
        {
            Order order = new Order();
            order.Identifier = identifier;
            order.Occurance = occurance;
            return order;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                if (_Identifier != value)
                {
                    OnIdentifierChanging(value);
                    ReportPropertyChanging("Identifier");
                    _Identifier = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Identifier");
                    OnIdentifierChanged();
                }
            }
        }
        private global::System.Int32 _Identifier;
        partial void OnIdentifierChanging(global::System.Int32 value);
        partial void OnIdentifierChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Occurance
        {
            get
            {
                return _Occurance;
            }
            set
            {
                OnOccuranceChanging(value);
                ReportPropertyChanging("Occurance");
                _Occurance = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Occurance");
                OnOccuranceChanged();
            }
        }
        private global::System.DateTime _Occurance;
        partial void OnOccuranceChanging(global::System.DateTime value);
        partial void OnOccuranceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        private global::System.Int32 DbStatus
        {
            get
            {
                return _DbStatus;
            }
            set
            {
                OnDbStatusChanging(value);
                ReportPropertyChanging("DbStatus");
                _DbStatus = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DbStatus");
                OnDbStatusChanged();
            }
        }
        private global::System.Int32 _DbStatus;
        partial void OnDbStatusChanging(global::System.Int32 value);
        partial void OnDbStatusChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "FK_OrderDetails_Orders", "OrderDetails")]
        private EntityCollection<OrderDetail> DbDetails
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<OrderDetail>("EFTestDatabaseModel.FK_OrderDetails_Orders", "OrderDetails");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<OrderDetail>("EFTestDatabaseModel.FK_OrderDetails_Orders", "OrderDetails", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EFTestDatabaseModel", Name="OrderDetail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class OrderDetail : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new OrderDetail object.
        /// </summary>
        /// <param name="identifier">Initial value of the Identifier property.</param>
        /// <param name="order">Initial value of the Order property.</param>
        /// <param name="product">Initial value of the Product property.</param>
        /// <param name="quantity">Initial value of the Quantity property.</param>
        public static OrderDetail CreateOrderDetail(global::System.Int32 identifier, global::System.Int32 order, global::System.Int32 product, global::System.Decimal quantity)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.Identifier = identifier;
            orderDetail.Order = order;
            orderDetail.Product = product;
            orderDetail.Quantity = quantity;
            return orderDetail;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                if (_Identifier != value)
                {
                    OnIdentifierChanging(value);
                    ReportPropertyChanging("Identifier");
                    _Identifier = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Identifier");
                    OnIdentifierChanged();
                }
            }
        }
        private global::System.Int32 _Identifier;
        partial void OnIdentifierChanging(global::System.Int32 value);
        partial void OnIdentifierChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Order
        {
            get
            {
                return _Order;
            }
            set
            {
                OnOrderChanging(value);
                ReportPropertyChanging("Order");
                _Order = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Order");
                OnOrderChanged();
            }
        }
        private global::System.Int32 _Order;
        partial void OnOrderChanging(global::System.Int32 value);
        partial void OnOrderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Product
        {
            get
            {
                return _Product;
            }
            set
            {
                OnProductChanging(value);
                ReportPropertyChanging("Product");
                _Product = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Product");
                OnProductChanged();
            }
        }
        private global::System.Int32 _Product;
        partial void OnProductChanging(global::System.Int32 value);
        partial void OnProductChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Decimal _Quantity;
        partial void OnQuantityChanging(global::System.Decimal value);
        partial void OnQuantityChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "FK_OrderDetails_Orders", "Orders")]
        private Order Order1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("EFTestDatabaseModel.FK_OrderDetails_Orders", "Orders").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("EFTestDatabaseModel.FK_OrderDetails_Orders", "Orders").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        private EntityReference<Order> Order1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("EFTestDatabaseModel.FK_OrderDetails_Orders", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Order>("EFTestDatabaseModel.FK_OrderDetails_Orders", "Orders", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "FK_OrderDetails_Products", "Products")]
        public Product Product1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("EFTestDatabaseModel.FK_OrderDetails_Products", "Products").Value;
            }
            private set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("EFTestDatabaseModel.FK_OrderDetails_Products", "Products").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Product> Product1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("EFTestDatabaseModel.FK_OrderDetails_Products", "Products");
            }
            private set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Product>("EFTestDatabaseModel.FK_OrderDetails_Products", "Products", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EFTestDatabaseModel", Name="Product")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Product : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Product object.
        /// </summary>
        /// <param name="identifier">Initial value of the Identifier property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static Product CreateProduct(global::System.Int32 identifier, global::System.String name, global::System.String description)
        {
            Product product = new Product();
            product.Identifier = identifier;
            product.Name = name;
            product.Description = description;
            return product;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                if (_Identifier != value)
                {
                    OnIdentifierChanging(value);
                    ReportPropertyChanging("Identifier");
                    _Identifier = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Identifier");
                    OnIdentifierChanged();
                }
            }
        }
        private global::System.Int32 _Identifier;
        partial void OnIdentifierChanging(global::System.Int32 value);
        partial void OnIdentifierChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Price
        {
            get
            {
                return _Price;
            }
            set
            {
                OnPriceChanging(value);
                ReportPropertyChanging("Price");
                _Price = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Price");
                OnPriceChanged();
            }
        }
        private Nullable<global::System.Decimal> _Price;
        partial void OnPriceChanging(Nullable<global::System.Decimal> value);
        partial void OnPriceChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "FK_OrderDetails_Products", "OrderDetails")]
        private EntityCollection<OrderDetail> OrderDetails
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<OrderDetail>("EFTestDatabaseModel.FK_OrderDetails_Products", "OrderDetails");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<OrderDetail>("EFTestDatabaseModel.FK_OrderDetails_Products", "OrderDetails", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EFTestDatabaseModel", "ProductCategories", "Categories")]
        private EntityCollection<Category> DbCategories
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Category>("EFTestDatabaseModel.ProductCategories", "Categories");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Category>("EFTestDatabaseModel.ProductCategories", "Categories", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
