using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C11 RID: 19473
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrBuildPanel : UiPanelBase
	{
		// Token: 0x06032CCE RID: 208078 RVA: 0x00CBA438 File Offset: 0x00CB8638
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06032CCF RID: 208079 RVA: 0x00CBA4C0 File Offset: 0x00CB86C0
		private InfrV2TreeBuild GetTreeConfig()
		{
			return ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId).Value;
		}

		// Token: 0x06032CD0 RID: 208080 RVA: 0x00CBA4E8 File Offset: 0x00CB86E8
		private string GetName()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				return this.GetTreeConfig().Name;
			}
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				return "VillageInfr_Name";
			}
			return "";
		}

		// Token: 0x06032CD1 RID: 208081 RVA: 0x00CBA524 File Offset: 0x00CB8724
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrBuildPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrBuildPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032CD2 RID: 208082 RVA: 0x00CBA568 File Offset: 0x00CB8768
		private void SetOpenParam()
		{
			IVillageInfrBuildInfoParam villageInfrBuildInfoParam = this.OpenParam as IVillageInfrBuildInfoParam;
			this.SelectType = villageInfrBuildInfoParam.SelectType;
			this.SelectId = villageInfrBuildInfoParam.SelectId;
		}

		// Token: 0x06032CD3 RID: 208083 RVA: 0x00CBA59C File Offset: 0x00CB879C
		private UniTask CreateInfoPanel()
		{
			VillageInfrBuildPanel.<CreateInfoPanel>d__9 <CreateInfoPanel>d__;
			<CreateInfoPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateInfoPanel>d__.<>4__this = this;
			<CreateInfoPanel>d__.<>1__state = -1;
			<CreateInfoPanel>d__.<>t__builder.Start<VillageInfrBuildPanel.<CreateInfoPanel>d__9>(ref <CreateInfoPanel>d__);
			return <CreateInfoPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032CD4 RID: 208084 RVA: 0x00CBA5E0 File Offset: 0x00CB87E0
		private UniTask CreateBottomPanel()
		{
			VillageInfrBuildPanel.<CreateBottomPanel>d__10 <CreateBottomPanel>d__;
			<CreateBottomPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBottomPanel>d__.<>4__this = this;
			<CreateBottomPanel>d__.<>1__state = -1;
			<CreateBottomPanel>d__.<>t__builder.Start<VillageInfrBuildPanel.<CreateBottomPanel>d__10>(ref <CreateBottomPanel>d__);
			return <CreateBottomPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032CD5 RID: 208085 RVA: 0x00CBA624 File Offset: 0x00CB8824
		protected override void OnStart()
		{
			this.RefreshName();
			this.RefreshTrace();
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06032CD6 RID: 208086 RVA: 0x00CBA657 File Offset: 0x00CB8857
		[NullableContext(2)]
		public void Refresh(IVillageInfrBuildInfoParam param = null)
		{
			if (param != null)
			{
				this.OpenParam = param;
				this.SetOpenParam();
			}
			this.InfoPanel.Refresh(param);
			this.BottomPanel.Refresh(param);
			this.RefreshTrace();
			this.RefreshName();
		}

		// Token: 0x06032CD7 RID: 208087 RVA: 0x00CBA68D File Offset: 0x00CB888D
		private void RefreshName()
		{
			base.GetText(1).ShowTextNew(this.GetName());
		}

		// Token: 0x06032CD8 RID: 208088 RVA: 0x00CBA6A1 File Offset: 0x00CB88A1
		private void RefreshTrace()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				base.GetSprite(2).SetUIActive(ModelBase<VillageInfrModel>.Instance.GetTraceTreeId() == this.SelectId);
				return;
			}
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x06032CD9 RID: 208089 RVA: 0x00CBA6D8 File Offset: 0x00CB88D8
		public void SetBottomBtnClickCb(Action cb)
		{
			this.BottomPanel.SetBottomBtnClickCb(cb);
		}

		// Token: 0x0401D901 RID: 121089
		private int SelectId;

		// Token: 0x0401D902 RID: 121090
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D903 RID: 121091
		private readonly VillageInfrBuildInfoPanel InfoPanel = new VillageInfrBuildInfoPanel();

		// Token: 0x0401D904 RID: 121092
		private readonly VillageInfrBuildBottomPanel BottomPanel = new VillageInfrBuildBottomPanel();
	}
}
