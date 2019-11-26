using NUnit.Framework;
using System;

namespace VynarN.Workshop.DynamicObjectCreator.Tests
{
    [TestFixture]
    public class CreatorTest
    {
        [Test]
        public void Get_3_Instances()
        {
            var creator = new Creator<VynarN.Workshop.TestLibrary.IService>(@"C:\Users\vynar\source\repos\Workshop\VynarN.Workshop.TestLibrary\bin\Debug\netcoreapp3.0");
            
            creator.CreateInstances();

            Assert.IsTrue(creator.Instances.Count == 3);
        }

        [Test]
        public void Cannot_Specify_emptyPath()
        {
            Assert.Throws<ArgumentException>(() => new Creator<VynarN.Workshop.TestLibrary.IService>(null));
        }
    }
}
