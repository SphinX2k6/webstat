using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002309 RID: 8969
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleScenePopupItem : GridProxyAbstract<int>
{
	// Token: 0x17001510 RID: 5392
	// (get) Token: 0x06011089 RID: 69769 RVA: 0x004AD3B7 File Offset: 0x004AB5B7
	// (set) Token: 0x0601108A RID: 69770 RVA: 0x004AD3BF File Offset: 0x004AB5BF
	public Action<int> OnClickToggleBack { get; set; }

	// Token: 0x17001511 RID: 5393
	// (get) Token: 0x0601108B RID: 69771 RVA: 0x004AD3C8 File Offset: 0x004AB5C8
	// (set) Token: 0x0601108C RID: 69772 RVA: 0x004AD3D0 File Offset: 0x004AB5D0
	public Func<int> GetCurrentSceneId { get; set; }

	// Token: 0x0601108D RID: 69773 RVA: 0x004AD3DC File Offset: 0x004AB5DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0601108E RID: 69774 RVA: 0x004AD49B File Offset: 0x004AB69B
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x0601108F RID: 69775 RVA: 0x004AD4BC File Offset: 0x004AB6BC
	public override void Refresh(int sceneId, bool isSelected, int gridIndex)
	{
		this.SceneId = new int?(sceneId);
		base.GridIndex = gridIndex;
		base.DisplayIndex = gridIndex;
		MotorScene? motorSceneConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSceneConfig(sceneId);
		if (motorSceneConfig == null)
		{
			return;
		}
		int currentSceneId = ModelBase<MotorcycleDiyModel>.Instance.GetCurrentSceneId();
		bool uiactive = sceneId == currentSceneId;
		bool flag = ModelBase<MotorcycleDiyModel>.Instance.HasScene(sceneId);
		base.SetTextureByPath(motorSceneConfig.Value.SceneIcon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), motorSceneConfig.Value.SceneName, Array.Empty<object>());
		base.GetItem(3).SetUIActive(uiactive);
		base.GetItem(4).SetUIActive(!flag);
		this.RefreshRedDot();
	}

	// Token: 0x06011090 RID: 69776 RVA: 0x004AD586 File Offset: 0x004AB786
	public override void Clear()
	{
		this.SceneId = null;
	}

	// Token: 0x06011091 RID: 69777 RVA: 0x004AD594 File Offset: 0x004AB794
	public void SetToggleState(bool isSelected, bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x06011092 RID: 69778 RVA: 0x004AD5AC File Offset: 0x004AB7AC
	public void RefreshRedDot()
	{
		if (this.SceneId == null)
		{
			return;
		}
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewScene(this.SceneId.Value));
	}

	// Token: 0x06011093 RID: 69779 RVA: 0x004AD5EE File Offset: 0x004AB7EE
	[NullableContext(1)]
	public override object GetKey(int data, int displayIndex)
	{
		return data;
	}

	// Token: 0x06011094 RID: 69780 RVA: 0x004AD5F6 File Offset: 0x004AB7F6
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06011095 RID: 69781 RVA: 0x004AD608 File Offset: 0x004AB808
	private bool CanExecuteChange()
	{
		if (this.SceneId == null)
		{
			return false;
		}
		Func<int> getCurrentSceneId = this.GetCurrentSceneId;
		int num = (getCurrentSceneId != null) ? getCurrentSceneId() : 0;
		return this.SceneId.Value != num;
	}

	// Token: 0x06011096 RID: 69782 RVA: 0x004AD648 File Offset: 0x004AB848
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.SceneId == null)
		{
			return;
		}
		Action<int> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.SceneId.Value);
	}

	// Token: 0x0400860B RID: 34315
	private int? SceneId;

	// Token: 0x0200860F RID: 34319
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402D58E RID: 185742
		public const int SceneToggle = 0;

		// Token: 0x0402D58F RID: 185743
		public const int SceneTexture = 1;

		// Token: 0x0402D590 RID: 185744
		public const int SceneNameText = 2;

		// Token: 0x0402D591 RID: 185745
		public const int CurrentMarkItem = 3;

		// Token: 0x0402D592 RID: 185746
		public const int LockItem = 4;

		// Token: 0x0402D593 RID: 185747
		public const int RedDotItem = 5;
	}
}
