using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.UnderseaExperimentField
{
	// Token: 0x02004B7E RID: 19326
	public class UnderseaExperimentToggleItem : UiPanelBase
	{
		// Token: 0x060327AC RID: 206764 RVA: 0x00CA13BC File Offset: 0x00C9F5BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060327AD RID: 206765 RVA: 0x00CA1428 File Offset: 0x00C9F628
		[NullableContext(1)]
		public UniTask Initialize(EDeepSeaMapId deepSeaMapId, UUIExtendToggle uiRoot)
		{
			UnderseaExperimentToggleItem.<Initialize>d__3 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.deepSeaMapId = deepSeaMapId;
			<Initialize>d__.uiRoot = uiRoot;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<UnderseaExperimentToggleItem.<Initialize>d__3>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x060327AE RID: 206766 RVA: 0x00CA147C File Offset: 0x00C9F67C
		public void RefreshPlayerIcon()
		{
			CustomizedThumbnail? customizedThumbnailConfig = ConfigBase<WorldMapConfig>.Instance.GetCustomizedThumbnailConfig(this.DeepSeaMapId);
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(new EAreaLevel?(EAreaLevel.FirstLevel));
			int? num = (customizedThumbnailConfig != null) ? new int?(customizedThumbnailConfig.GetValueOrDefault().AreaId) : null;
			bool uiactive = currentAreaId == num.GetValueOrDefault() & num != null;
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0401D730 RID: 120624
		private EDeepSeaMapId DeepSeaMapId = EDeepSeaMapId.Graveyard;

		// Token: 0x0200AC4A RID: 44106
		public static class EComponents
		{
			// Token: 0x04035937 RID: 219447
			public const int Cursor = 0;

			// Token: 0x04035938 RID: 219448
			public const int PlayerIcon = 1;
		}
	}
}
