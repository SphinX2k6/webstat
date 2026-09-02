using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

// Token: 0x02001FB9 RID: 8121
[NullableContext(1)]
[Nullable(0)]
public class StrengthUnit : HudUnitBase
{
	// Token: 0x0600F4A3 RID: 62627 RVA: 0x0042F16C File Offset: 0x0042D36C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F4A4 RID: 62628 RVA: 0x0042F218 File Offset: 0x0042D418
	protected override void OnStart()
	{
		base.OnStart();
		this.ItemList.Add(base.GetItem(0));
		this.ItemList.Add(base.GetItem(1));
		this.ItemList.Add(base.GetItem(0));
		this.ItemList.Add(base.GetItem(0));
		base.InitTweenAnim(2);
		base.InitTweenAnim(3);
		this.AddStrengthItem(EStrengthItemType.Default, 0);
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("OverShoulderViewStrengthUnitPos");
		if (floatArrayConfig != null && floatArrayConfig.Count >= 2)
		{
			this.OverShoulderViewOffset[0] = floatArrayConfig[0];
			this.OverShoulderViewOffset[1] = floatArrayConfig[1];
		}
	}

	// Token: 0x0600F4A5 RID: 62629 RVA: 0x0042F2C0 File Offset: 0x0042D4C0
	protected override void OnBeforeDestroy()
	{
		this.RoleData = null;
		this.ActorComponent = null;
		foreach (StrengthItemBase child in this.StrengthItemMap.Values)
		{
			base.AddChild(child);
		}
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F4A6 RID: 62630 RVA: 0x0042F32C File Offset: 0x0042D52C
	[NullableContext(2)]
	public void RefreshRoleData(BattleUiRoleData roleData)
	{
		if (this.RoleData == roleData)
		{
			return;
		}
		this.RoleData = roleData;
		if (roleData == null)
		{
			this.ActorComponent = null;
			return;
		}
		EntityHandle entityHandle = roleData.EntityHandle;
		CharacterActorComponent actorComponent;
		if (entityHandle == null)
		{
			actorComponent = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			actorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		this.ActorComponent = actorComponent;
		foreach (StrengthItemBase strengthItemBase in this.StrengthItemMap.Values)
		{
			strengthItemBase.RefreshRoleData(roleData);
		}
	}

	// Token: 0x0600F4A7 RID: 62631 RVA: 0x0042F3C4 File Offset: 0x0042D5C4
	public unsafe void AddStrengthItem(EStrengthItemType strengthItemType, int index)
	{
		if (this.StrengthItemMap.ContainsKey(strengthItemType))
		{
			return;
		}
		if (index < 0 || index > 3)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HudUnit;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "体力条位置参数非法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.StrengthItemTypeList[index] != EStrengthItemType.None)
		{
			if (index == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.HudUnit;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "该位置已有其他体力条";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("oldStrengthItemType", this.StrengthItemTypeList[index]);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newStrengthItemType", strengthItemType);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			StrengthItemBase strengthItemBase;
			if (this.StrengthItemMap.TryGetValue(this.StrengthItemTypeList[index], out strengthItemBase))
			{
				strengthItemBase.Destroy(null);
				this.StrengthItemMap.Remove(this.StrengthItemTypeList[index]);
			}
		}
		Type type;
		if (!this.StrengthItemConfigMap.TryGetValue(strengthItemType, out type))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.HudUnit;
			ELogAuthor author3 = ELogAuthor.CFT;
			string message3 = "体力条类型没有对应的实现";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("strengthItemType", strengthItemType);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		this.StrengthItemTypeList[index] = strengthItemType;
		UUIItem parentItem = this.ItemList[index];
		StrengthItemBase strengthItemBase2 = (StrengthItemBase)Activator.CreateInstance(type);
		strengthItemBase2.Init(parentItem, this.RoleData, new Action<bool>(this.OnItemUiVisibleChanged));
		this.StrengthItemMap[strengthItemType] = strengthItemBase2;
	}

	// Token: 0x0600F4A8 RID: 62632 RVA: 0x0042F54C File Offset: 0x0042D74C
	public void SetStandardBarMode(bool b = true, bool force = false)
	{
		if (this.IsStandardBarMode == b && !force)
		{
			return;
		}
		this.IsStandardBarMode = b;
		if (this.IsShowMotorFly())
		{
			this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.NormalIndex[0], false, false);
			this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.SpecialNormalIndex[0], false, false);
			this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.Special2NormalIndex[0], true, force);
			return;
		}
		this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.NormalIndex[0], b, false);
		this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.SpecialNormalIndex[0], !b, false);
		this.<SetStandardBarMode>g__SetStrengthItem|34_0(StrengthUnit.Special2NormalIndex[0], false, false);
	}

	// Token: 0x0600F4A9 RID: 62633 RVA: 0x0042F5D3 File Offset: 0x0042D7D3
	public void SwapPlace(bool value)
	{
		if (this.IsSwapPlace == value)
		{
			return;
		}
		this.IsSwapPlace = value;
		this.RefreshItemPlace();
	}

	// Token: 0x0600F4AA RID: 62634 RVA: 0x0042F5EC File Offset: 0x0042D7EC
	private void OnItemUiVisibleChanged(bool uiVisible)
	{
		this.RefreshItemPlace();
		this.UpdateMotorBarState(this.IsMotorSoaring);
	}

	// Token: 0x0600F4AB RID: 62635 RVA: 0x0042F600 File Offset: 0x0042D800
	private void RefreshItemPlace()
	{
		bool flag = true;
		foreach (EStrengthItemType key in this.StrengthItemTypeList)
		{
			StrengthItemBase strengthItemBase;
			if (!this.StrengthItemMap.TryGetValue(key, out strengthItemBase) || !strengthItemBase.GetUiVisible())
			{
				flag = false;
			}
		}
		if (!flag)
		{
			int[] array;
			if (this.IsStandardBarMode)
			{
				array = (this.IsSwapPlace ? StrengthUnit.SwapIndex : StrengthUnit.NormalIndex);
			}
			else
			{
				array = (this.IsShowMotorFly() ? (this.IsSwapPlace ? StrengthUnit.Special2SwapIndex : StrengthUnit.Special2NormalIndex) : (this.IsSwapPlace ? StrengthUnit.SpecialSwapIndex : StrengthUnit.SpecialNormalIndex));
			}
			int num = 0;
			bool flag2 = true;
			foreach (int num2 in array)
			{
				UUIItem uuiitem = this.ItemList[num2];
				EStrengthItemType key2 = this.StrengthItemTypeList[num2];
				StrengthItemBase strengthItemBase2;
				if (this.StrengthItemMap.TryGetValue(key2, out strengthItemBase2) && strengthItemBase2.GetUiVisible())
				{
					uuiitem.SetAnchorOffsetX(157f + 105f * (float)num);
					uuiitem.SetAlpha(flag2 ? 1f : 0.3f);
					uuiitem.SetUIItemScale(global::Vector.OneVector);
					num++;
				}
				flag2 = false;
			}
			return;
		}
		if (this.IsSwapPlace)
		{
			base.StopTweenAnim(2);
			base.PlayTweenAnim(3);
			return;
		}
		base.StopTweenAnim(3);
		base.PlayTweenAnim(2);
	}

	// Token: 0x0600F4AC RID: 62636 RVA: 0x0042F75D File Offset: 0x0042D95D
	public void UpdateMotorBarState(bool b)
	{
		this.IsMotorSoaring = b;
		if (this.IsDriving)
		{
			this.SetStandardBarMode(!this.IsShowMotorFly(), true);
			this.SwapPlace(!b);
		}
	}

	// Token: 0x0600F4AD RID: 62637 RVA: 0x0042F788 File Offset: 0x0042D988
	public void SetDriving(bool b)
	{
		this.IsDriving = b;
	}

	// Token: 0x0600F4AE RID: 62638 RVA: 0x0042F794 File Offset: 0x0042D994
	private bool IsShowMotorFly()
	{
		if (!this.IsDriving)
		{
			return false;
		}
		StrengthItemBase strengthItemBase;
		bool flag = this.StrengthItemMap.TryGetValue(EStrengthItemType.Motorcycle, out strengthItemBase) && strengthItemBase.IsShowOrShowing;
		StrengthItemBase strengthItemBase2;
		bool flag2 = this.StrengthItemMap.TryGetValue(EStrengthItemType.MotorcycleFly, out strengthItemBase2) && strengthItemBase2.IsShowOrShowing;
		StrengthItemBase strengthItemBase3;
		bool flag3 = this.StrengthItemMap.TryGetValue(EStrengthItemType.Default, out strengthItemBase3) && strengthItemBase3.IsShowOrShowing;
		return this.IsMotorSoaring || (flag2 && flag) || !flag3;
	}

	// Token: 0x0600F4AF RID: 62639 RVA: 0x0042F80F File Offset: 0x0042DA0F
	public void SetFirstPersonState(bool b)
	{
		this.IsFirstPersonView = b;
	}

	// Token: 0x0600F4B0 RID: 62640 RVA: 0x0042F818 File Offset: 0x0042DA18
	public void SetOverShoulderState(bool value)
	{
		this.IsOverShoulderView = value;
	}

	// Token: 0x0600F4B1 RID: 62641 RVA: 0x0042F824 File Offset: 0x0042DA24
	public override void Tick(float delta)
	{
		this.RefreshTargetPosition(delta);
		foreach (StrengthItemBase strengthItemBase in this.StrengthItemMap.Values)
		{
			strengthItemBase.Tick(delta);
		}
	}

	// Token: 0x0600F4B2 RID: 62642 RVA: 0x0042F884 File Offset: 0x0042DA84
	private void RefreshTargetPosition(float delta)
	{
		if (!base.GetActive())
		{
			return;
		}
		if (this.IsOverShoulderView)
		{
			if (!this.OffsetX.Equals(this.OverShoulderViewOffset[0]) || !this.OffsetY.Equals(this.OverShoulderViewOffset[1]))
			{
				this.OffsetX = this.OverShoulderViewOffset[0];
				this.OffsetY = this.OverShoulderViewOffset[1];
				base.SetAnchorOffset(this.OffsetX, this.OffsetY);
			}
			return;
		}
		if (this.IsFirstPersonView)
		{
			if (!this.OffsetX.Equals(600f) || this.OffsetY != 0f)
			{
				this.OffsetX = 600f;
				this.OffsetY = 0f;
				base.SetAnchorOffset(this.OffsetX, this.OffsetY);
			}
			return;
		}
		CharacterActorComponent actorComponent = this.ActorComponent;
		bool flag;
		if (actorComponent == null)
		{
			flag = true;
		}
		else
		{
			TsBaseCharacter actor = actorComponent.Actor;
			flag = !((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		FVectorDouble actorLocation = this.ActorComponent.ActorLocation;
		if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, this.ScreenPos))
		{
			return;
		}
		float num = (float)this.ScreenPos.X;
		float num2 = (float)this.ScreenPos.Y;
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
		base.SetAnchorOffset(this.OffsetX, this.OffsetY);
	}

	// Token: 0x0600F4B3 RID: 62643 RVA: 0x0042FAA4 File Offset: 0x0042DCA4
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
		float num2 = (delta >= 200f) ? (num / delta) : (num / 200f);
		if (flag)
		{
			num2 = -num2;
		}
		return (float)Singleton<MathUtils>.Instance.Lerp((double)lastSpeed, (double)num2, 0.5);
	}

	// Token: 0x0600F4B5 RID: 62645 RVA: 0x0042FBCC File Offset: 0x0042DDCC
	// Note: this type is marked as 'beforefieldinit'.
	static StrengthUnit()
	{
		int[] array = new int[2];
		array[0] = 1;
		StrengthUnit.SwapIndex = array;
		StrengthUnit.SpecialNormalIndex = new int[]
		{
			2,
			1
		};
		StrengthUnit.SpecialSwapIndex = new int[]
		{
			1,
			2
		};
		StrengthUnit.Special2NormalIndex = new int[]
		{
			3,
			1
		};
		StrengthUnit.Special2SwapIndex = new int[]
		{
			1,
			3
		};
	}

	// Token: 0x0600F4B6 RID: 62646 RVA: 0x0042FC44 File Offset: 0x0042DE44
	[CompilerGenerated]
	private void <SetStandardBarMode>g__SetStrengthItem|34_0(int i, bool enable, bool forceInner = false)
	{
		EStrengthItemType key = this.StrengthItemTypeList[i];
		StrengthItemBase strengthItemBase;
		if (this.StrengthItemMap.TryGetValue(key, out strengthItemBase))
		{
			strengthItemBase.SetEnableStrengthItem(enable, forceInner);
		}
	}

	// Token: 0x040075E0 RID: 30176
	private const float MaxDeltaTime = 200f;

	// Token: 0x040075E1 RID: 30177
	private const float MinDeltaOffset = 0.5f;

	// Token: 0x040075E2 RID: 30178
	private const float MaxPosOffset = 500f;

	// Token: 0x040075E3 RID: 30179
	private const float ItemOffsetXBase = 157f;

	// Token: 0x040075E4 RID: 30180
	private const float ItemOffsetXInterval = 105f;

	// Token: 0x040075E5 RID: 30181
	[StaticVariableRuleIgnore]
	private static readonly int[] NormalIndex = new int[]
	{
		0,
		1
	};

	// Token: 0x040075E6 RID: 30182
	[StaticVariableRuleIgnore]
	private static readonly int[] SwapIndex;

	// Token: 0x040075E7 RID: 30183
	[StaticVariableRuleIgnore]
	private static readonly int[] SpecialNormalIndex;

	// Token: 0x040075E8 RID: 30184
	[StaticVariableRuleIgnore]
	private static readonly int[] SpecialSwapIndex;

	// Token: 0x040075E9 RID: 30185
	[StaticVariableRuleIgnore]
	private static readonly int[] Special2NormalIndex;

	// Token: 0x040075EA RID: 30186
	[StaticVariableRuleIgnore]
	private static readonly int[] Special2SwapIndex;

	// Token: 0x040075EB RID: 30187
	private const float FirstPersonOffsetX = 600f;

	// Token: 0x040075EC RID: 30188
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x040075ED RID: 30189
	[Nullable(2)]
	private BattleUiRoleData RoleData;

	// Token: 0x040075EE RID: 30190
	[Nullable(2)]
	private CharacterActorComponent ActorComponent;

	// Token: 0x040075EF RID: 30191
	private float OffsetX;

	// Token: 0x040075F0 RID: 30192
	private float OffsetY;

	// Token: 0x040075F1 RID: 30193
	private float SpeedX;

	// Token: 0x040075F2 RID: 30194
	private float SpeedY;

	// Token: 0x040075F3 RID: 30195
	private readonly List<UUIItem> ItemList = new List<UUIItem>();

	// Token: 0x040075F4 RID: 30196
	private readonly Dictionary<EStrengthItemType, StrengthItemBase> StrengthItemMap = new Dictionary<EStrengthItemType, StrengthItemBase>();

	// Token: 0x040075F5 RID: 30197
	private bool IsSwapPlace;

	// Token: 0x040075F6 RID: 30198
	private bool IsStandardBarMode = true;

	// Token: 0x040075F7 RID: 30199
	private readonly EStrengthItemType[] StrengthItemTypeList = new EStrengthItemType[4];

	// Token: 0x040075F8 RID: 30200
	private bool IsFirstPersonView;

	// Token: 0x040075F9 RID: 30201
	private bool IsOverShoulderView;

	// Token: 0x040075FA RID: 30202
	private readonly float[] OverShoulderViewOffset = new float[2];

	// Token: 0x040075FB RID: 30203
	private readonly Dictionary<EStrengthItemType, Type> StrengthItemConfigMap = new Dictionary<EStrengthItemType, Type>
	{
		{
			EStrengthItemType.Default,
			typeof(StrengthItem)
		},
		{
			EStrengthItemType.Fly,
			typeof(FlyStrengthItem)
		},
		{
			EStrengthItemType.MotorcycleFly,
			typeof(FlyStrengthItemForMotorcycle)
		},
		{
			EStrengthItemType.Motorcycle,
			typeof(MotorcycleStrengthItem)
		},
		{
			EStrengthItemType.StrengthForAimisi,
			typeof(StrengthItemForAimisi)
		},
		{
			EStrengthItemType.QingXiaoFly,
			typeof(FlyStrengthItemForQingXiao)
		}
	};

	// Token: 0x040075FC RID: 30204
	private bool IsMotorSoaring;

	// Token: 0x040075FD RID: 30205
	private bool IsDriving;

	// Token: 0x0200834C RID: 33612
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C87A RID: 182394
		Item1,
		// Token: 0x0402C87B RID: 182395
		Item2,
		// Token: 0x0402C87C RID: 182396
		AniSwitchIn,
		// Token: 0x0402C87D RID: 182397
		AniSwitchOut
	}
}
