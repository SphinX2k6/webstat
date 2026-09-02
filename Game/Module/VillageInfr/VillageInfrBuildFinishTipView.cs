using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C15 RID: 19477
	public class VillageInfrBuildFinishTipView : UiViewBase
	{
		// Token: 0x06032CE3 RID: 208099 RVA: 0x00CBA9F9 File Offset: 0x00CB8BF9
		[NullableContext(1)]
		public VillageInfrBuildFinishTipView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032CE4 RID: 208100 RVA: 0x00CBAA04 File Offset: 0x00CB8C04
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickMask))
			};
		}

		// Token: 0x06032CE5 RID: 208101 RVA: 0x00CBAA97 File Offset: 0x00CB8C97
		private void OnClickMask()
		{
			base.CloseMe(null);
		}

		// Token: 0x06032CE6 RID: 208102 RVA: 0x00CBAAA0 File Offset: 0x00CB8CA0
		protected override void OnStart()
		{
			IVillageInfrBuildFinishTipParam villageInfrBuildFinishTipParam = this.OpenParam as IVillageInfrBuildFinishTipParam;
			if (villageInfrBuildFinishTipParam.SelectType == EVillageInfrSelectType.Tree)
			{
				InfrV2TreeBuild? infrTreeBuild = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(villageInfrBuildFinishTipParam.SelectId);
				base.GetText(0).ShowTextNew("VillageInfr_TreeTips_Finish1");
				base.GetText(1).ShowTextNew(infrTreeBuild.Value.Name);
				base.GetText(2).ShowTextNew("VillageInfr_TreeTips_Finish2");
				return;
			}
			int selectId = villageInfrBuildFinishTipParam.SelectId;
			InfrV2Level? infrLevel = ConfigBase<VillageInfrConfig>.Instance.GetInfrLevel(selectId);
			base.GetText(0).ShowTextNew("VillageInfr_VillageTips_Upgrade");
			base.GetText(1).ShowTextNew(infrLevel.Value.Name);
			if (selectId >= ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel())
			{
				base.GetText(2).ShowTextNew("VillageInfr_VillageTips_Highest");
				UUIItem text = base.GetText(2);
				bool bUseChangeColor = true;
				FColor? fcolor = new FColor?(base.GetText(2).changeColor);
				text.SetChangeColor(bUseChangeColor, fcolor);
				return;
			}
			base.GetText(2).ShowTextNew("VillageInfr_VillageTips_Continue");
		}
	}
}
