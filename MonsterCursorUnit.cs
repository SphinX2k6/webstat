using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FB4 RID: 8116
public class MonsterCursorUnit : HudUnitBase
{
	// Token: 0x0600F46B RID: 62571 RVA: 0x0042DC88 File Offset: 0x0042BE88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F46C RID: 62572 RVA: 0x0042DD75 File Offset: 0x0042BF75
	[NullableContext(1)]
	public void Activate(HudEntityData hudEntity)
	{
		this.HudEntity = hudEntity;
		this.AddEntityEvents();
		this.RefreshState();
		if (base.GetActive())
		{
			this.SetActive(false);
		}
	}

	// Token: 0x0600F46D RID: 62573 RVA: 0x0042DD99 File Offset: 0x0042BF99
	public void Deactivate()
	{
		if (this.HudEntity == null)
		{
			return;
		}
		this.HudEntity.ClearAllTagCountChangedCallback();
		this.HudEntity = null;
	}

	// Token: 0x0600F46E RID: 62574 RVA: 0x0042DDB8 File Offset: 0x0042BFB8
	protected virtual void AddEntityEvents()
	{
		this.HudEntity.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagRefresh));
		this.HudEntity.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.部分动作"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagRefresh));
		this.HudEntity.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.瘫痪中"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagRefresh));
	}

	// Token: 0x0600F46F RID: 62575 RVA: 0x0042DE37 File Offset: 0x0042C037
	private void OnTagRefresh(int tagId, bool tagExist)
	{
		this.RefreshState();
	}

	// Token: 0x0600F470 RID: 62576 RVA: 0x0042DE40 File Offset: 0x0042C040
	public int? GetEntityId()
	{
		HudEntityData hudEntity = this.HudEntity;
		if (hudEntity == null)
		{
			return null;
		}
		return new int?(hudEntity.GetId());
	}

	// Token: 0x0600F471 RID: 62577 RVA: 0x0042DE6B File Offset: 0x0042C06B
	public bool IsValid()
	{
		return this.HudEntity != null;
	}

	// Token: 0x0600F472 RID: 62578 RVA: 0x0042DE76 File Offset: 0x0042C076
	[NullableContext(2)]
	public HudEntityData GetHudEntityData()
	{
		return this.HudEntity;
	}

	// Token: 0x0600F473 RID: 62579 RVA: 0x0042DE80 File Offset: 0x0042C080
	public void Refresh(float scale, FVector2D position)
	{
		if (scale != this.CurScale)
		{
			this.CurScale = scale;
			base.GetUiNiagara((int)(3 + this.CurState)).SetNiagaraVarFloat("Scale", scale);
		}
		float inYaw = MathF.Atan2(position.Y, position.X) * 57.295776f - 90f;
		UUIItem rootItem = this.RootItem;
		FRotator frotator = new FRotator(0f, inYaw, 0f);
		rootItem.SetUIRelativeRotation(frotator);
		this.RootItem.SetAnchorOffset(position);
	}

	// Token: 0x0600F474 RID: 62580 RVA: 0x0042DF00 File Offset: 0x0042C100
	private void RefreshState()
	{
		int num;
		if (this.HudEntity.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.瘫痪中"]))
		{
			num = 2;
		}
		else if (this.HudEntity.ContainsTagById(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		if (this.CurState == (MonsterCursorUnit.EState)num)
		{
			return;
		}
		this.CurState = (MonsterCursorUnit.EState)num;
		for (int i = 0; i < 3; i++)
		{
			base.GetItem(i).SetUIActive(i == num);
		}
		base.GetUiNiagara(3 + num).SetNiagaraVarFloat("Scale", this.CurScale);
	}

	// Token: 0x040075A6 RID: 30118
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x040075A7 RID: 30119
	private const int CURSOR_NUM = 3;

	// Token: 0x040075A8 RID: 30120
	[Nullable(2)]
	private HudEntityData HudEntity;

	// Token: 0x040075A9 RID: 30121
	private MonsterCursorUnit.EState CurState;

	// Token: 0x040075AA RID: 30122
	private float CurScale = 1f;

	// Token: 0x02008345 RID: 33605
	private enum EState
	{
		// Token: 0x0402C859 RID: 182361
		Normal,
		// Token: 0x0402C85A RID: 182362
		Skill,
		// Token: 0x0402C85B RID: 182363
		FallDown
	}

	// Token: 0x02008346 RID: 33606
	private enum EChildType
	{
		// Token: 0x0402C85D RID: 182365
		CommonCursorItem,
		// Token: 0x0402C85E RID: 182366
		FoundCursorItem,
		// Token: 0x0402C85F RID: 182367
		FallDownCursorItem,
		// Token: 0x0402C860 RID: 182368
		CommonNiagara,
		// Token: 0x0402C861 RID: 182369
		FoundNiagara,
		// Token: 0x0402C862 RID: 182370
		FallDownNiagara
	}
}
