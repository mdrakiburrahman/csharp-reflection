using System.Reflection;

namespace Reflection.HugeHack
{
    public static class ReflectionHelper
    {
        public static object GetFieldValue(this object obj, string fieldName)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            FieldInfo fieldInfo = GetFieldInfo(objType, fieldName);
            if (fieldInfo == null)
                throw new MissingFieldException(
                    "fieldName",
                    string.Format(
                        "Couldn't find field {0} in type {1}",
                        fieldName,
                        objType.FullName
                    )
                );
            return fieldInfo.GetValue(obj);
        }

        public static void SetFieldValue(this object obj, string fieldName, object val)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            FieldInfo fieldInfo = GetFieldInfo(objType, fieldName);
            if (fieldInfo == null)
                throw new MissingFieldException(
                    "fieldName",
                    string.Format(
                        "Couldn't find field {0} in type {1}",
                        fieldName,
                        objType.FullName
                    )
                );
            fieldInfo.SetValue(obj, val);
        }

        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
            if (propInfo == null)
                throw new MissingMemberException(
                    "propertyName",
                    string.Format(
                        "Couldn't find property {0} in type {1}",
                        propertyName,
                        objType.FullName
                    )
                );
            return propInfo.GetValue(obj, null);
        }

        public static void SetPropertyValue(this object obj, string propertyName, object val)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
            if (propInfo == null)
                throw new MissingMemberException(
                    "propertyName",
                    string.Format(
                        "Couldn't find property {0} in type {1}",
                        propertyName,
                        objType.FullName
                    )
                );
            propInfo.SetValue(obj, val, null);
        }

        private static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            FieldInfo fieldInfo;
            do
            {
                fieldInfo = type.GetField(
                    fieldName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                );
                type = type.BaseType;
            } while (fieldInfo == null && type != null);
            return fieldInfo;
        }

        private static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            PropertyInfo propInfo = null;
            do
            {
                propInfo = type.GetProperty(
                    propertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                );
                type = type.BaseType;
            } while (propInfo == null && type != null);
            return propInfo;
        }
    }
}
