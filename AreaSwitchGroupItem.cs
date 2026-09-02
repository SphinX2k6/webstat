using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002287 RID: 8839
public class AreaSwitchGroupItem : UiPanelBase
{
	// Token: 0x06010B5C RID: 68444 RVA: 0x00493868 File Offset: 0x00491A68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickLastBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickNextBtn))
		};
	}

	// Token: 0x06010B5D RID: 68445 RVA: 0x00493914 File Offset: 0x00491B14
	[NullableContext(1)]
	public void RefreshAreaList(List<int> areaIdList, int selectAreaId)
	{
		this.AreaIdList = areaIdList;
		int num = areaIdList.IndexOf(selectAreaId);
		this.SelectAreaIndex = ((num >= 0) ? num : 0);
		this.Refresh();
	}

	// Token: 0x06010B5E RID: 68446 RVA: 0x00493944 File Offset: 0x00491B44
	private void Refresh()
	{
		int num = this.AreaIdList[this.SelectAreaIndex];
		MotorRoleCategory? config = ConfigMotorRoleCategoryById.GetConfig(num, true);
		if (config == null)
		{
			return;
		}
		MotorRoleCategory valueOrDefault = config.GetValueOrDefault();
		MotorRoleCategory motorRoleCategory = valueOrDefault;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), motorRoleCategory.RegionName, Array.Empty<object>());
		this.SetSpriteByPath(motorRoleCategory.Icon, base.GetSprite(0), false, null, null);
		Action<int> onSwitchCallBack = this.OnSwitchCallBack;
		if (onSwitchCallBack == null)
		{
			return;
		}
		onSwitchCallBack(num);
	}

	// Token: 0x06010B5F RID: 68447 RVA: 0x004939CF File Offset: 0x00491BCF
	private void OnClickLastBtn()
	{
		this.SelectAreaIndex--;
		if (this.SelectAreaIndex < 0)
		{
			this.SelectAreaIndex = this.AreaIdList.Count - 1;
		}
		this.Refresh();
	}

	// Token: 0x06010B60 RID: 68448 RVA: 0x00493A01 File Offset: 0x00491C01
	private void OnClickNextBtn()
	{
		this.SelectAreaIndex++;
		if (this.SelectAreaIndex >= this.AreaIdList.Count)
		{
			this.SelectAreaIndex = 0;
		}
		this.Refresh();
	}

	// Token: 0x040083E2 RID: 33762
	[Nullable(1)]
	private List<int> AreaIdList = new List<int>();

	// Token: 0x040083E3 RID: 33763
	private int SelectAreaIndex;

	// Token: 0x040083E4 RID: 33764
	[Nullable(2)]
	public Action<int> OnSwitchCallBack;

	// Token: 0x0200854C RID: 34124
	private class EComponents
	{
		// Token: 0x0402D1CB RID: 184779
		public const int SpriteIcon = 0;

		// Token: 0x0402D1CC RID: 184780
		public const int TxtTitle = 1;

		// Token: 0x0402D1CD RID: 184781
		public const int BtnLast = 2;

		// Token: 0x0402D1CE RID: 184782
		public const int BtnNext = 3;
	}
}
