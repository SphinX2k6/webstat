using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FB7 RID: 8119
[NullableContext(1)]
[Nullable(0)]
public class RoverlikeBossCursorUnit : HudUnitBase
{
	// Token: 0x0600F486 RID: 62598 RVA: 0x0042E74C File Offset: 0x0042C94C
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F487 RID: 62599 RVA: 0x0042E7F8 File Offset: 0x0042C9F8
	protected override void OnStart()
	{
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
		this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
		this.DirectionArrow = base.GetItem(0);
		this.DirectionArrowRed = base.GetItem(3);
	}

	// Token: 0x0600F488 RID: 62600 RVA: 0x0042E882 File Offset: 0x0042CA82
	protected override void OnBeforeShow()
	{
		this.TickEnabled = true;
	}

	// Token: 0x0600F489 RID: 62601 RVA: 0x0042E88B File Offset: 0x0042CA8B
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600F48A RID: 62602 RVA: 0x0042E894 File Offset: 0x0042CA94
	public void Activate(EntityHandle entityHandle)
	{
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.Deactivate();
			return;
		}
		this.EntityHandle = entityHandle;
		WorldEntity entity = this.EntityHandle.Entity;
		this.ActorComp = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
		WorldEntity entity2 = this.EntityHandle.Entity;
		this.TagComp = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
		this.AddEntityEvents();
		this.RefreshState(false);
		base.SetVisible(true, 0);
	}

	// Token: 0x0600F48B RID: 62603 RVA: 0x0042E90F File Offset: 0x0042CB0F
	public void Deactivate()
	{
		this.RemoveEntityEvents();
		this.EntityHandle = null;
		this.ActorComp = null;
		base.SetVisible(false, 0);
	}

	// Token: 0x0600F48C RID: 62604 RVA: 0x0042E930 File Offset: 0x0042CB30
	public override void Tick(float deltaTime)
	{
		if (!this.TickEnabled)
		{
			return;
		}
		if (this.ActorComp == null)
		{
			return;
		}
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.Deactivate();
			return;
		}
		this.UpdateTargetPosition(this.ActorComp.ActorLocation);
	}

	// Token: 0x0600F48D RID: 62605 RVA: 0x0042E980 File Offset: 0x0042CB80
	public void UpdateTargetPosition(FVectorDouble targetPosition)
	{
		TsCharacterController characterController = Global.CharacterController;
		bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, targetPosition, ref this.ScreenPositionRef, false);
		if (!flag)
		{
			FTransformDouble? cameraTransform = ModelBase<CameraModel>.Instance.MainModel.CameraTransform;
			FVectorDouble fvectorDouble = cameraTransform.Value.InverseTransformPositionNoScale(targetPosition);
			fvectorDouble.X = -fvectorDouble.X;
			FVectorDouble fvectorDouble2 = cameraTransform.Value.TransformPositionNoScale(fvectorDouble);
			UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble2, ref this.ScreenPositionRef, false);
		}
		this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
		if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
		{
			this.LastScreenPosition.DeepCopy(this.ScreenPosition);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
			this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
			this.RootItem.SetAnchorOffset(this.ScreenPosition.ToUeVector2D(false));
			if (!this.InRange)
			{
				this.TempRotator.Reset();
				this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875 - 90.0);
				FRotator frotator = this.TempRotator.ToUeRotator();
				this.DirectionArrow.SetUIRelativeRotation(frotator);
				this.DirectionArrowRed.SetUIRelativeRotation(frotator);
				base.SetUiActive(true);
				return;
			}
			base.SetUiActive(false);
		}
	}

	// Token: 0x0600F48E RID: 62606 RVA: 0x0042EB30 File Offset: 0x0042CD30
	protected bool ClampToEllipse(Vector2D vector, bool inFront)
	{
		double x = vector.X;
		double y = vector.Y;
		float limitA = this.LimitA;
		float limitB = this.LimitB;
		if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
		{
			return true;
		}
		double inB = (double)(limitA * limitB) / Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
		vector.MultiplyEqual(inB);
		return false;
	}

	// Token: 0x0600F48F RID: 62607 RVA: 0x0042EBA1 File Offset: 0x0042CDA1
	protected void AddEntityEvents()
	{
		this.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"], new Action<int, bool>(this.OnTagRefresh));
	}

	// Token: 0x0600F490 RID: 62608 RVA: 0x0042EBC4 File Offset: 0x0042CDC4
	protected void OnTagRefresh(int tagId, bool tagExist)
	{
		this.RefreshState(false);
	}

	// Token: 0x0600F491 RID: 62609 RVA: 0x0042EBD0 File Offset: 0x0042CDD0
	protected void RefreshState(bool bForce = false)
	{
		BaseTagComponent tagComp = this.TagComp;
		int num;
		if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		if (this.CurState == (RoverlikeBossCursorUnit.EState)num && !bForce)
		{
			return;
		}
		this.CurState = (RoverlikeBossCursorUnit.EState)num;
		UUITexture texture = base.GetTexture(2);
		FColor? fcolor;
		if (num == 1)
		{
			base.GetItem(1).SetUIActive(true);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = true;
			fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.DirectionArrow.SetUIActive(false);
			this.DirectionArrowRed.SetUIActive(true);
			return;
		}
		base.GetItem(1).SetUIActive(false);
		UUIItem uuiitem2 = texture;
		bool bUseChangeColor2 = false;
		fcolor = new FColor?(texture.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		this.DirectionArrow.SetUIActive(true);
		this.DirectionArrowRed.SetUIActive(false);
	}

	// Token: 0x0600F492 RID: 62610 RVA: 0x0042EC9D File Offset: 0x0042CE9D
	protected void RemoveEntityEvents()
	{
		this.ClearAllTagTask();
	}

	// Token: 0x0600F493 RID: 62611 RVA: 0x0042ECA8 File Offset: 0x0042CEA8
	protected void ListenForTagAddOrRemoveChanged(int tagId, Action<int, bool> onTagChange)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null)
		{
			return;
		}
		ITagTask tagTask = tagComp.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(onTagChange.Invoke), null);
		if (tagTask != null)
		{
			this.TagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0600F494 RID: 62612 RVA: 0x0042ECEC File Offset: 0x0042CEEC
	protected void ClearAllTagTask()
	{
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x040075C2 RID: 30146
	private const float MAX_A = 1176f;

	// Token: 0x040075C3 RID: 30147
	private const float MARGIN_A = 1008f;

	// Token: 0x040075C4 RID: 30148
	private const float MAX_B = 712.5f;

	// Token: 0x040075C5 RID: 30149
	private const float MARGIN_B = 495f;

	// Token: 0x040075C6 RID: 30150
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x040075C7 RID: 30151
	[Nullable(2)]
	protected UUIItem DirectionArrow;

	// Token: 0x040075C8 RID: 30152
	[Nullable(2)]
	protected UUIItem DirectionArrowRed;

	// Token: 0x040075C9 RID: 30153
	protected FVector2D ScreenPositionRef;

	// Token: 0x040075CA RID: 30154
	protected Vector2D ScreenPosition = Vector2D.Create();

	// Token: 0x040075CB RID: 30155
	protected Vector2D LastScreenPosition = Vector2D.Create();

	// Token: 0x040075CC RID: 30156
	protected readonly Vector2D PointTransport = new Vector2D(1.0, -1.0);

	// Token: 0x040075CD RID: 30157
	protected bool InRange;

	// Token: 0x040075CE RID: 30158
	protected Rotator TempRotator = Rotator.Create();

	// Token: 0x040075CF RID: 30159
	protected float LimitA;

	// Token: 0x040075D0 RID: 30160
	protected float LimitB;

	// Token: 0x040075D1 RID: 30161
	protected bool TickEnabled;

	// Token: 0x040075D2 RID: 30162
	[Nullable(2)]
	protected EntityHandle EntityHandle;

	// Token: 0x040075D3 RID: 30163
	[Nullable(2)]
	protected BaseActorComponent ActorComp;

	// Token: 0x040075D4 RID: 30164
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x040075D5 RID: 30165
	protected readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x040075D6 RID: 30166
	protected RoverlikeBossCursorUnit.EState CurState;

	// Token: 0x02008348 RID: 33608
	[NullableContext(0)]
	protected enum EState
	{
		// Token: 0x0402C866 RID: 182374
		Normal,
		// Token: 0x0402C867 RID: 182375
		Skill,
		// Token: 0x0402C868 RID: 182376
		FallDown
	}

	// Token: 0x02008349 RID: 33609
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402C869 RID: 182377
		public const int DirectionArrow = 0;

		// Token: 0x0402C86A RID: 182378
		public const int BgLightItem = 1;

		// Token: 0x0402C86B RID: 182379
		public const int BgTex = 2;

		// Token: 0x0402C86C RID: 182380
		public const int DirectionArrowRed = 3;
	}
}
