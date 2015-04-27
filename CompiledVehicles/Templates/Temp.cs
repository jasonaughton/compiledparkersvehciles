using System;

namespace CompiledVehicles.Templates
{
    /// <summary>
    /// Class MakeAttribute.
    /// </summary>
    public class MakeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MakeAttribute" /> class.
        /// </summary>
        /// <param name="makeType">Type of the make.</param>
        public MakeAttribute(Type makeType)
        {
            this.Make = makeType;
        }

        /// <summary>
        /// Gets the make.
        /// </summary>
        public Type Make
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Class ModelAttribute.
    /// </summary>
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        public ModelAttribute(Type modelType)
        {
        }
    }

    /// <summary>
    /// Class RangeAttribute.
    /// </summary>
    public class RangeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAttribute"/> class.
        /// </summary>
        /// <param name="rangeType">Type of the range.</param>
        public RangeAttribute(Type rangeType)
        {
        }
    }

    /// <summary>
    /// Class IdAttribute.
    /// </summary>
    public class IdAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdAttribute"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public IdAttribute(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Interface IMake
    /// </summary>
    public interface ICompiledMake
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }
    }

    /// <summary>
    /// Interface IModel
    /// </summary>
    public interface ICompiledModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
