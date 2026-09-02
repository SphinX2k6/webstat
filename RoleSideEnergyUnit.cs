using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

// Token: 0x02001FB6 RID: 8118
public class RoleSideEnergyUnit : HudUnitBase
{
	// Token: 0x0600F47C RID: 62588 RVA: 0x0042E3C0 File Offset: 0x0042C5C0
	[NullableContext(1)]
	public void InitInfo(GameplayCue cueConfig, BattleUiRoleData roleData)
	{
		this.CueConfig = new GameplayCue?(cueConfig);
		this.RoleData = roleData;
		this.AttrId = (EAttributeType)cueConfig.AttrId;
		this.MaxAttrId = CharacterAttributeTypes.attributeIdsWithMax.GetValueOrDefault(this.AttrId, EAttributeType.None);
		this.AddEvents();
		this.RefreshBarPercent();
	}

	// Token: 0x0600F47D RID: 62589 RVA: 0x0042E410 File Offset: 0x0042C610
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F47E RID: 62590 RVA: 0x0042E458 File Offset: 0x0042C658
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvents();
		this.CueConfig = null;
		this.RoleData = null;
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F47F RID: 62591 RVA: 0x0042E47C File Offset: 0x0042C67C
	protected virtual void AddEvents()
	{
		if (this.AttrId != EAttributeType.None)
		{
			BattleUiRoleData roleData = this.RoleData;
			if (((roleData != null) ? roleData.AttributeComponent : null) != null)
			{
				this.RoleData.AttributeComponent.AddListener(this.AttrId, new Action<EAttributeType, float, float>(this.OnAttrChanged), null);
				this.RoleData.AttributeComponent.AddListener(this.MaxAttrId, new Action<EAttributeType, float, float>(this.OnAttrChanged), null);
				return;
			}
		}
	}

	// Token: 0x0600F480 RID: 62592 RVA: 0x0042E4EC File Offset: 0x0042C6EC
	protected virtual void RemoveEvents()
	{
		if (this.AttrId != EAttributeType.None)
		{
			BattleUiRoleData roleData = this.RoleData;
			if (((roleData != null) ? roleData.AttributeComponent : null) != null)
			{
				this.RoleData.AttributeComponent.RemoveListener(this.AttrId, new Action<EAttributeType, float, float>(this.OnAttrChanged));
				this.RoleData.AttributeComponent.RemoveListener(this.MaxAttrId, new Action<EAttributeType, float, float>(this.OnAttrChanged));
				return;
			}
		}
	}

	// Token: 0x0600F481 RID: 62593 RVA: 0x0042E55C File Offset: 0x0042C75C
	protected void OnAttrChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.RefreshBarPercent();
	}

	// Token: 0x0600F482 RID: 62594 RVA: 0x0042E564 File Offset: 0x0042C764
	protected virtual void RefreshBarPercent()
	{
		if (this.AttrId != EAttributeType.None)
		{
			BattleUiRoleData roleData = this.RoleData;
			if (((roleData != null) ? roleData.AttributeComponent : null) != null)
			{
				float currentValue = this.RoleData.AttributeComponent.GetCurrentValue(this.AttrId);
				float currentValue2 = this.RoleData.AttributeComponent.GetCurrentValue(this.MaxAttrId);
				float fillAmount = (currentValue2 == 0f) ? 0f : (currentValue / currentValue2);
				base.GetSprite(0).SetFillAmount(fillAmount);
				return;
			}
		}
	}

	// Token: 0x0600F483 RID: 62595 RVA: 0x0042E5DC File Offset: 0x0042C7DC
	[NullableContext(1)]
	public void RefreshTargetPosition(float delta, Vector2D screenPos)
	{
		float num = (float)screenPos.X;
		float num2 = (float)screenPos.Y;
		if (Math.Abs(num - this.OffsetX) > 500f || Math.Abs(num2 - this.OffsetY) > 500f)
		{
			this.OffsetX = num;
			this.OffsetY = num2;
			base.SetAnchorOffset(this.OffsetX, this.OffsetY);
			return;
		}
		this.SpeedX = this.GetSpeed(delta, num, this.OffsetX, this.SpeedX);
		this.SpeedY = this.GetSpeed(delta, num2, this.OffsetY, this.SpeedY);
		float num3 = this.SpeedX * delta;
		float num4 = this.SpeedY * delta;
		if (num3 < 0.5f && num3 > -0.5f && num4 < 0.5f && num4 > -0.5f)
		{
			return;
		}
		this.OffsetX += num3;
		this.OffsetY += num4;
		base.SetAnchorOffset(this.OffsetX + -150f, this.OffsetY);
	}

	// Token: 0x0600F484 RID: 62596 RVA: 0x0042E6E0 File Offset: 0x0042C8E0
	private float GetSpeed(float delta, float target, float cur, float lastSpeed)
	{
		float num = target - cur;
		bool flag = false;
		if (num < 0f)
		{
			num = -num;
			flag = true;
		}
		if (num < 1f)
		{
			return 0f;
		}
		float num2;
		if (delta >= 200f)
		{
			num2 = num / delta;
		}
		else
		{
			num2 = num / 200f;
		}
		if (flag)
		{
			num2 = -num2;
		}
		return Singleton<MathUtils>.Instance.Lerp(lastSpeed, num2, 0.5f);
	}

	// Token: 0x040075B6 RID: 30134
	private const float MAX_DELTA_TIME = 200f;

	// Token: 0x040075B7 RID: 30135
	private const float MIN_DELTA_OFFSET = 0.5f;

	// Token: 0x040075B8 RID: 30136
	private const float MAX_POS_OFFSET = 500f;

	// Token: 0x040075B9 RID: 30137
	private const float OFFSET_X = -150f;

	// Token: 0x040075BA RID: 30138
	protected GameplayCue? CueConfig;

	// Token: 0x040075BB RID: 30139
	[Nullable(2)]
	protected BattleUiRoleData RoleData;

	// Token: 0x040075BC RID: 30140
	protected EAttributeType AttrId;

	// Token: 0x040075BD RID: 30141
	protected EAttributeType MaxAttrId;

	// Token: 0x040075BE RID: 30142
	protected float OffsetX;

	// Token: 0x040075BF RID: 30143
	protected float OffsetY;

	// Token: 0x040075C0 RID: 30144
	protected float SpeedX;

	// Token: 0x040075C1 RID: 30145
	protected float SpeedY;

	// Token: 0x02008347 RID: 33607
	private enum EChildType
	{
		// Token: 0x0402C864 RID: 182372
		BarSprite
	}
}
