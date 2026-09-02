using System;
using CSharpScript.Game.Capability;

// Token: 0x02000E41 RID: 3649
// (Invoke) Token: 0x06005765 RID: 22373
public delegate T TCapabilityDataCtor<T>(ICapabilityGameObject owner) where T : CapabilityData;
