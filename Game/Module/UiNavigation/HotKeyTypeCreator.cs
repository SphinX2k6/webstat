using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D79 RID: 19833
	public class HotKeyTypeCreator
	{
		// Token: 0x060335FB RID: 210427 RVA: 0x00CD9ADC File Offset: 0x00CD7CDC
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<HotKeyTypeBase> CreateHotKeyType(AActor actor, int typeId, bool isMultiKeyItem)
		{
			HotKeyTypeCreator.<CreateHotKeyType>d__0 <CreateHotKeyType>d__;
			<CreateHotKeyType>d__.<>t__builder = AsyncUniTaskMethodBuilder<HotKeyTypeBase>.Create();
			<CreateHotKeyType>d__.actor = actor;
			<CreateHotKeyType>d__.typeId = typeId;
			<CreateHotKeyType>d__.isMultiKeyItem = isMultiKeyItem;
			<CreateHotKeyType>d__.<>1__state = -1;
			<CreateHotKeyType>d__.<>t__builder.Start<HotKeyTypeCreator.<CreateHotKeyType>d__0>(ref <CreateHotKeyType>d__);
			return <CreateHotKeyType>d__.<>t__builder.Task;
		}
	}
}
