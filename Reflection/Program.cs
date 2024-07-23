using Reflection.HugeHack;
using Reflection.OverProtective;

SomeClass someObj = new SomeClass();

// the Str and Int properties will be found on the first step of iteration, 
// so, the base class won't be analyzed
//
string currentStrValue = (string)someObj.GetPropertyValue("Str");
int currentIntValue = (int)someObj.GetPropertyValue("Int");

// the IsLimited property will be found on the second step of iteration, 
// so, the base class will be analyzed as well
//
bool currentBoolValue = (bool)someObj.GetPropertyValue("IsLimited");

// the Str and Int properties will be found on the first step of iteration, 
// so, the base class won't be analyzed
//
someObj.SetPropertyValue("Str", "brand new value");
someObj.SetPropertyValue("Int", -1);

// the IsLimited propertiy will be found on the second step of iteration, 
// so, the base class will be analyzed as well
//
someObj.SetPropertyValue("IsLimited", true);

// set value
//
someObj.SetFieldValue("_connectionString", "some connection string");

// get value
//
string privateValue = (string)someObj.GetFieldValue("_connectionString");