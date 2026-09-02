using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022C8 RID: 8904
public class MotorcycleTechTreeDetailView : UiViewBase
{
	// Token: 0x06010D85 RID: 68997 RVA: 0x0049C3D7 File Offset: 0x0049A5D7
	[NullableContext(1)]
	public MotorcycleTechTreeDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D86 RID: 68998 RVA: 0x0049C3E0 File Offset: 0x0049A5E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout))
		};
	}

	// Token: 0x06010D87 RID: 68999 RVA: 0x0049C450 File Offset: 0x0049A650
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
		this.Layout = new GenericLayout<MotorcycleTechTreeListScrollItem, IMotorTechOverviewData>(base.GetVerticalLayout(3), new Func<MotorcycleTechTreeListScrollItem>(this.InitListItem), null, false, true);
		int? num = this.OpenParam as int?;
		if (num == null)
		{
			return;
		}
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(num.Value);
		if (motorTechTreeConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorTechTreeConfig.Value.Icon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), motorTechTreeConfig.Value.Name, Array.Empty<object>());
		List<IMotorTechOverviewData> list = new List<IMotorTechOverviewData>();
		foreach (MotorTech motorTech in ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(num.Value))
		{
			MotorTechTreeNode techNodeById = ModelBase<MotorcycleDevelopModel>.Instance.GetTechNodeById(motorTech.Id);
			if (techNodeById != null && techNodeById.Status == EMotorTechTreeNodeStatus.Activated)
			{
				MotorTechOverviewData item = new MotorTechOverviewData
				{
					TechId = motorTech.Id,
					Level = techNodeById.NodeLevel
				};
				list.Add(item);
			}
		}
		list.Sort(delegate(IMotorTechOverviewData a, IMotorTechOverviewData b)
		{
			MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(a.TechId);
			MotorTech? motorTechConfig2 = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(b.TechId);
			return motorTechConfig.Value.DetailOrder - motorTechConfig2.Value.DetailOrder;
		});
		this.Layout.RefreshByData(list, null, false);
	}

	// Token: 0x06010D88 RID: 69000 RVA: 0x0049C5F8 File Offset: 0x0049A7F8
	[NullableContext(1)]
	private MotorcycleTechTreeListScrollItem InitListItem()
	{
		return new MotorcycleTechTreeListScrollItem();
	}

	// Token: 0x06010D89 RID: 69001 RVA: 0x0049C5FF File Offset: 0x0049A7FF
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x040084C5 RID: 33989
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040084C6 RID: 33990
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeListScrollItem, IMotorTechOverviewData> Layout;

	// Token: 0x02008593 RID: 34195
	private class EMotorTechTreeDetailComponent
	{
		// Token: 0x0402D312 RID: 185106
		public const int CaptionItem = 0;

		// Token: 0x0402D313 RID: 185107
		public const int TexIcon = 1;

		// Token: 0x0402D314 RID: 185108
		public const int TxtAttr = 2;

		// Token: 0x0402D315 RID: 185109
		public const int Layout = 3;
	}
}
