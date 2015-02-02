//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace Orleans.Samples.ClassScheduler.Gain.Interface
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Collections.Generic;
    using Orleans;
    using Orleans.Runtime;
    using System.Collections;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.970.29197")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class CollegeClassFactory
    {
        

                        public static Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass GetGrain(System.Guid primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass), -877677476, primaryKey));
                        }

                        public static Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass GetGrain(System.Guid primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass), -877677476, primaryKey, grainClassNamePrefix));
                        }

            public static Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return CollegeClassReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.970.29197")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("Orleans.Samples.ClassScheduler.Gain.Interface.Orleans.Samples.ClassScheduler.Gain" +
            ".Interface.ICollegeClass")]
        internal class CollegeClassReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass
        {
            

            public static Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass) global::Orleans.Runtime.GrainReference.CastInternal(typeof(Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass), (global::Orleans.Runtime.GrainReference gr) => { return new CollegeClassReference(gr);}, grainRef, -877677476);
            }
            
            protected internal CollegeClassReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal CollegeClassReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -877677476;
                }
            }
            
            protected override string InterfaceName
            {
                get
                {
                    return "Orleans.Samples.ClassScheduler.Gain.Interface.Orleans.Samples.ClassScheduler.Gain" +
                        ".Interface.ICollegeClass";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                CollegeClassReference input = ((CollegeClassReference)(original));
                return ((CollegeClassReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                CollegeClassReference input = ((CollegeClassReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return CollegeClassReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return ((interfaceId == this.InterfaceId) 
                            || (interfaceId == -1097320095));
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return CollegeClassMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass.Configure(string name, string subject)
            {

                return base.InvokeMethodAsync<object>(-1038651987, new object[] {name, subject} );
            }
            
            System.Threading.Tasks.Task<string> Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass.GetName()
            {

                return base.InvokeMethodAsync<System.String>(-1256896228, new object[] {} );
            }
            
            System.Threading.Tasks.Task<string> Orleans.Samples.ClassScheduler.Gain.Interface.ICollegeClass.GetSubject()
            {

                return base.InvokeMethodAsync<System.String>(-1553342840, new object[] {} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.970.29197")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("Orleans.Samples.ClassScheduler.Gain.Interface.Orleans.Samples.ClassScheduler.Gain" +
        ".Interface.ICollegeClass", -877677476)]
    internal class CollegeClassMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -877677476;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {{                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -877677476:  // ICollegeClass
                        switch (methodId)
                        {
                            case -1038651987: 
                                return ((ICollegeClass)grain).Configure((String)arguments[0], (String)arguments[1]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case -1256896228: 
                                return ((ICollegeClass)grain).GetName().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            case -1553342840: 
                                return ((ICollegeClass)grain).GetSubject().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }case -1097320095:  // IGrainWithGuidKey
                        switch (methodId)
                        {
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }}
            catch(Exception ex)
            {{
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }}
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -877677476:  // ICollegeClass
                    switch (methodId)
                    {
                        case -1038651987:
                            return "Configure";
                    case -1256896228:
                            return "GetName";
                    case -1553342840:
                            return "GetSubject";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }
                case -1097320095:  // IGrainWithGuidKey
                    switch (methodId)
                    {
                        
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
