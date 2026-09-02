using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006278 RID: 25208
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPreviewPersonalizedSubView : TotalTopUpPreviewSubViewBase
	{
		// Token: 0x0603F7D4 RID: 260052 RVA: 0x010470EC File Offset: 0x010452EC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
		}

		// Token: 0x0603F7D5 RID: 260053 RVA: 0x01047148 File Offset: 0x01045348
		public unsafe override void ShowPreview(ITotalTopUpPreviewViewParam param)
		{
			int? num;
			if (param == null)
			{
				num = null;
			}
			else
			{
				TotalTopUpRewardData rewardData = param.RewardData;
				num = ((rewardData != null) ? new int?(rewardData.PreviewButtonRegistry.Count) : null);
			}
			int? num2 = num;
			if (num2.GetValueOrDefault() == 0)
			{
				return;
			}
			this.ItemIdList = new List<int>(param.RewardData.ItemIdList);
			for (int i = 0; i < param.RewardData.PreviewButtonRegistry.Count; i++)
			{
				int num3 = param.RewardData.ItemIdList[i];
				int num4;
				if (param.RewardData.ItemMap.TryGetValue(num3, out num4))
				{
					int num5 = param.RewardData.PreviewButtonRegistry[i];
					string message = "设置个性化饰品预览按钮";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", i);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("道具ID", num3);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("按钮索引", num5);
					TotalTopUpUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					UUIButtonComponent button = base.GetButton(num5);
					if (button != null)
					{
						int capturedI = i;
						button.OnClickCallBack.Bind(delegate()
						{
							this.OnClick(capturedI);
						});
					}
				}
			}
		}

		// Token: 0x0603F7D6 RID: 260054 RVA: 0x010472B8 File Offset: 0x010454B8
		private void OnClick(int index)
		{
			int num = this.ItemIdList[index];
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(num) : null;
			if (itemConfig == null)
			{
				string message = "未找到个性化饰品道具配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", num);
				TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (ValueTuple<Func<int, CSharpScript.Game.Module.Inventory.ItemConfig, bool>, Action<int, CSharpScript.Game.Module.Inventory.ItemConfig>> valueTuple2 in TotalTopUpDefine.itemTipsFunctionList)
			{
				Func<int, CSharpScript.Game.Module.Inventory.ItemConfig, bool> item = valueTuple2.Item1;
				Action<int, CSharpScript.Game.Module.Inventory.ItemConfig> item2 = valueTuple2.Item2;
				if (item(num, itemConfig))
				{
					item2(num, itemConfig);
					return;
				}
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num, false, null);
		}

		// Token: 0x04023A3E RID: 145982
		private List<int> ItemIdList = new List<int>();
	}
}
