using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200325B RID: 12891
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterAnimOptimizationSetting : Singleton<CharacterAnimOptimizationSetting>
{
	// Token: 0x0601ADD7 RID: 110039 RVA: 0x008043B5 File Offset: 0x008025B5
	public CharacterAnimOptimizationSetting()
	{
		EVisibilityBasedAnimTickOption[] array = new EVisibilityBasedAnimTickOption[9];
		RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.D2DCD027297326BE5922C0FDABEA867C1FD485C387D3D910C582B914204C7DAB).FieldHandle);
		this.DisableAnimOptimizationTypeDefines = array;
		base..ctor();
	}

	// Token: 0x0400DA22 RID: 55842
	public readonly EVisibilityBasedAnimTickOption[] DisableAnimOptimizationTypeDefines;
}
