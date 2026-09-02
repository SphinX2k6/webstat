using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Module
{
	// Token: 0x020044E1 RID: 17633
	public abstract class BaseResourceModule : IResourceTypeModule
	{
		// Token: 0x0602E80A RID: 190474
		public abstract UniTask<bool> PrepareManifests();

		// Token: 0x0602E80B RID: 190475
		[NullableContext(1)]
		public abstract PackClassification ClassifyPacks(ResourceSelectionContext context, bool forceMax = false);

		// Token: 0x0602E80C RID: 190476
		[NullableContext(1)]
		public abstract long GetLocalSize(IReadOnlyList<string> pakNames);

		// Token: 0x0602E80D RID: 190477
		[NullableContext(1)]
		public abstract void Delete(IReadOnlyList<string> pakNames);

		// Token: 0x0602E80E RID: 190478 RVA: 0x00B03328 File Offset: 0x00B01528
		protected void DegradeToMinPack()
		{
			Singleton<LauncherLog>.Instance.Info("Optional package 玩家执行了资源清理，包体选择记录退化为精简包", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<EResUpdateType>(ELauncherStorageDeviceKey.SelectedMaxOrMinPackType, EResUpdateType.Min);
		}
	}
}
