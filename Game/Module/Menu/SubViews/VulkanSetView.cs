using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x020057A3 RID: 22435
	[NullableContext(1)]
	[Nullable(0)]
	public class VulkanSetView : UiViewBase
	{
		// Token: 0x060390B3 RID: 233651 RVA: 0x00E74949 File Offset: 0x00E72B49
		public VulkanSetView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060390B4 RID: 233652 RVA: 0x00E7497C File Offset: 0x00E72B7C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x060390B5 RID: 233653 RVA: 0x00E74A04 File Offset: 0x00E72C04
		protected override UniTask OnBeforeStartAsync()
		{
			VulkanSetView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VulkanSetView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060390B6 RID: 233654 RVA: 0x00E74A48 File Offset: 0x00E72C48
		private ISetItemData[] InitData()
		{
			List<ISetItemData> list = new List<ISetItemData>();
			int num = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.Vulkan, 0, true);
			MenuConfig value = ConfigBase<MenuBaseConfig>.Instance.GetMenuConfigByFunctionId(20360).Value;
			string[] array = value.OptionsName();
			int[] array2 = value.OptionsValue();
			int num2 = array2.ToList<int>().IndexOf(num);
			if (num2 < 0)
			{
				num = value.OptionsDefault;
				num2 = array2.ToList<int>().IndexOf(num);
			}
			this.CurrentIndex = num2;
			this.SelectValue = num;
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(new SetItemData
				{
					Index = i,
					Value = array2[i],
					Name = ((array2[i] == 0) ? "ToolsImageSetOpenGLES_Text" : "ToolsImageSetVulkan_Text")
				});
			}
			return list.ToArray();
		}

		// Token: 0x060390B7 RID: 233655 RVA: 0x00E74B20 File Offset: 0x00E72D20
		protected override void OnBeforeShow()
		{
			base.GetItem(4).SetUIActive(this.IsNeedTipsActive());
			this.ScrollView.SelectGridProxy(this.CurrentIndex, false);
		}

		// Token: 0x060390B8 RID: 233656 RVA: 0x00E74B46 File Offset: 0x00E72D46
		private SetItem InitSetItem()
		{
			return new SetItem
			{
				CallbackClickItem = new Action<ISetItemData>(this.OnClickItemToggle)
			};
		}

		// Token: 0x060390B9 RID: 233657 RVA: 0x00E74B5F File Offset: 0x00E72D5F
		private void OnClickItemToggle(ISetItemData data)
		{
			this.SelectValue = data.Value;
			this.ScrollView.SelectGridProxy(data.Index, false);
			base.GetItem(4).SetUIActive(this.IsNeedTipsActive());
		}

		// Token: 0x060390BA RID: 233658 RVA: 0x00E74B91 File Offset: 0x00E72D91
		private void OnClickCancel(int _)
		{
			base.CloseMe(null);
		}

		// Token: 0x060390BB RID: 233659 RVA: 0x00E74B9A File Offset: 0x00E72D9A
		private void OnClickConfirm(int _)
		{
			if (this.SelectValue < 0)
			{
				return;
			}
			Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.Vulkan, this.SelectValue, EGameSettingsApplyReason.WhenUi);
			base.CloseMe(null);
		}

		// Token: 0x060390BC RID: 233660 RVA: 0x00E74BC4 File Offset: 0x00E72DC4
		private bool IsNeedTipsActive()
		{
			string a = this.mobileRhiNameList[this.SelectValue];
			string rhiname = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIName();
			return a != rhiname;
		}

		// Token: 0x0402079D RID: 133021
		private const EFunction vulkanFunctionId = EFunction.Vulkan;

		// Token: 0x0402079E RID: 133022
		private string[] mobileRhiNameList = new string[]
		{
			"OpenGL",
			"Vulkan"
		};

		// Token: 0x0402079F RID: 133023
		private int CurrentIndex = -1;

		// Token: 0x040207A0 RID: 133024
		private int SelectValue = -1;

		// Token: 0x040207A1 RID: 133025
		[Nullable(2)]
		private ButtonItem BtnCancel;

		// Token: 0x040207A2 RID: 133026
		[Nullable(2)]
		private ButtonItem BtnConfirm;

		// Token: 0x040207A3 RID: 133027
		[Nullable(2)]
		private TipsItem ItemTips;

		// Token: 0x040207A4 RID: 133028
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<SetItem, ISetItemData> ScrollView;
	}
}
