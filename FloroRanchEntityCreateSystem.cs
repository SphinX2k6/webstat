using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BF1 RID: 7153
public class FloroRanchEntityCreateSystem
{
	// Token: 0x0600D028 RID: 53288 RVA: 0x00374318 File Offset: 0x00372518
	[NullableContext(1)]
	public static FloroRanchEntityBase CreateFloroRanchEntity(FloroRanchPlayUnit entityData)
	{
		FloroRanchEntityCreateData floroRanchEntityComponentDefine = FloroRanchEntityDefine.GetFloroRanchEntityComponentDefine((EFloroRanchEntityType)entityData.Type);
		FloroRanchEntityBase floroRanchEntityBase = new FloroRanchEntityBase(entityData);
		foreach (ValueTuple<Type, Func<FloroRanchEntityComponentBase>> valueTuple in floroRanchEntityComponentDefine.Components)
		{
			floroRanchEntityBase.AddComponent(valueTuple.Item1, valueTuple.Item2);
		}
		floroRanchEntityBase.Init();
		floroRanchEntityBase.RefreshEntityData(entityData);
		return floroRanchEntityBase;
	}
}
