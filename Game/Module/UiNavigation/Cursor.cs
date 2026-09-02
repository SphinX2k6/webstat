using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C7F RID: 19583
	[NullableContext(1)]
	[Nullable(0)]
	public class Cursor : IStaticVariableResetter
	{
		// Token: 0x060330A0 RID: 209056 RVA: 0x00CC857D File Offset: 0x00CC677D
		static Cursor()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(Cursor.CreateStaticDefaultValue), new Action(Cursor.ResetStaticDefaultValue));
		}

		// Token: 0x17008796 RID: 34710
		// (get) Token: 0x060330A1 RID: 209057 RVA: 0x00CC859C File Offset: 0x00CC679C
		private static Vector TempLocation
		{
			get
			{
				if (Cursor._tempLocation == null)
				{
					Cursor._tempLocation = new Vector();
				}
				return Cursor._tempLocation;
			}
		}

		// Token: 0x17008797 RID: 34711
		// (get) Token: 0x060330A2 RID: 209058 RVA: 0x00CC85B4 File Offset: 0x00CC67B4
		private static Rotator OriRotator
		{
			get
			{
				if (Cursor._oriRotator == null)
				{
					Cursor._oriRotator = new Rotator();
				}
				return Cursor._oriRotator;
			}
		}

		// Token: 0x17008798 RID: 34712
		// (get) Token: 0x060330A3 RID: 209059 RVA: 0x00CC85CC File Offset: 0x00CC67CC
		private static Rotator TempRotator
		{
			get
			{
				if (Cursor._tempRotator == null)
				{
					Cursor._tempRotator = new Rotator();
				}
				return Cursor._tempRotator;
			}
		}

		// Token: 0x17008799 RID: 34713
		// (get) Token: 0x060330A4 RID: 209060 RVA: 0x00CC85E4 File Offset: 0x00CC67E4
		private static Vector TempFollowLocation
		{
			get
			{
				if (Cursor._tempFollowLocation == null)
				{
					Cursor._tempFollowLocation = new Vector();
				}
				return Cursor._tempFollowLocation;
			}
		}

		// Token: 0x1700879A RID: 34714
		// (get) Token: 0x060330A5 RID: 209061 RVA: 0x00CC85FC File Offset: 0x00CC67FC
		private static Vector TempThirdLocation
		{
			get
			{
				if (Cursor._tempThirdLocation == null)
				{
					Cursor._tempThirdLocation = new Vector();
				}
				return Cursor._tempThirdLocation;
			}
		}

		// Token: 0x060330A6 RID: 209062 RVA: 0x00CC8614 File Offset: 0x00CC6814
		private void CreateOriginalItem()
		{
			if (this.OriginalParentItem != null && this.OriginalParentItem.IsValid())
			{
				return;
			}
			if (this.AsyncLoadId == Singleton<LguiResourceManager>.Instance.InvalidId)
			{
				this.AsyncLoadId = Singleton<LguiResourceManager>.Instance.LoadPrefabByResourceId("UiItem_Cursor_Prefab", Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pool), delegate([Nullable(2)] AActor actor, string assetPath, ELguiLoadResultType loadResultType)
				{
					this.AsyncLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;
					Singleton<LguiUtil>.Instance.SetActorIsPermanent(actor, true, true);
					this.OriginalParentItem = (actor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
					this.OriginalItem = this.OriginalParentItem.UIChildren.Get(0);
					this.OriginalItem.SetUIActive(false);
				}, "Ui.CommonUi");
			}
		}

		// Token: 0x060330A7 RID: 209063 RVA: 0x00CC8680 File Offset: 0x00CC6880
		protected void RefreshUseItem()
		{
			if (this.UseItem != null && this.UseItem.IsValid())
			{
				return;
			}
			this.CreateOriginalItem();
			if (this.OriginalParentItem == null || !this.OriginalParentItem.IsValid())
			{
				return;
			}
			if (this.OriginalItem == null || !this.OriginalItem.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "光标原始节点出现问题", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UseItem = Singleton<LguiUtil>.Instance.CopyItem(this.OriginalItem, this.OriginalParentItem);
			Singleton<LguiUtil>.Instance.SetActorIsPermanent(this.UseItem.GetOwner(), true, true);
			this.IsInFloat = false;
			this.UpdateCursorItemAttachParent();
			this.IsUseItemActive = this.UseItem.IsUIActiveSelf();
			bool value = this.FollowItem != null;
			this.TrySetUseItemUiActive(value);
			Cursor.TempLocation.Set(0.0, 0.0, 0.0);
			Cursor.TempRotator.Set(0f, 0f, 0f);
			FRotator frotator = this.UseItem.GetOwner().K2_GetActorRotation();
			Cursor.OriRotator.Set(frotator.Pitch, frotator.Yaw, frotator.Roll);
		}

		// Token: 0x060330A8 RID: 209064 RVA: 0x00CC87C4 File Offset: 0x00CC69C4
		private void SetUseItemMoveInstantly()
		{
			if (this.UseItem == null || this.FollowItem == null)
			{
				return;
			}
			FVectorDouble fvectorDouble = this.FollowItem.D_K2_GetComponentLocation();
			FVector fvector = fvectorDouble;
			fvectorDouble = this.FollowItem.D_K2_GetComponentScale();
			FVector fvector2 = fvectorDouble;
			Cursor.TempFollowLocation.Set((double)(fvector.X + Cursor.TempOffsetX * fvector2.X), 0.0, (double)(fvector.Z + Cursor.TempOffsetY * fvector2.Y));
			Cursor.TempThirdLocation.DeepCopy(Cursor.TempFollowLocation);
			Cursor.TempLocation.DeepCopy(Cursor.TempFollowLocation);
			Cursor.TempRotator.DeepCopy(Cursor.OriRotator);
			Cursor.TempRotator.Pitch += (float)this.TempRotation;
			this.AppliedRotation = this.TempRotation;
			this.RotationTransitionRemaining = 0f;
			FHitResult fhitResult = new FHitResult();
			this.UseItem.GetOwner().D_K2_SetActorLocationAndRotation(Cursor.TempFollowLocation.ToUeVector(false), Cursor.TempRotator.ToUeRotator(), false, ref fhitResult, false);
		}

		// Token: 0x060330A9 RID: 209065 RVA: 0x00CC88D4 File Offset: 0x00CC6AD4
		private void UpdateCursorItemAttachParent()
		{
			if (this.UseItem == null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VideoView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NetWorkConfirmBoxView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadFreeSpaceTipsView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadMobileClearPopView))
			{
				if (this.IsInFloat)
				{
					this.UseItem.SetUIParent(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Mask), false);
					this.IsInFloat = false;
					return;
				}
			}
			else if (!this.IsInFloat)
			{
				this.UseItem.SetUIParent(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Float), false);
				this.IsInFloat = true;
			}
		}

		// Token: 0x060330AA RID: 209066 RVA: 0x00CC8994 File Offset: 0x00CC6B94
		public void SetFollowItem(TsUiNavigationBehaviorListener listener)
		{
			this.Listener = listener;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (listener != null) ? new TWeakObjectPtr<UUIItem>?(listener.RootUIComp) : null;
			this.FollowItem = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
			this.TotalSpeed = 0f;
			this.MoveTickTime = 0f;
			Cursor.TempWidth = 0f;
			Cursor.TempHeight = 0f;
			if (listener == null)
			{
				this.TrySetUseItemUiActive(false);
			}
			else
			{
				this.IsNeedMove = true;
				this.IsCursorOpen = listener.Cursor.Switch;
				this.CacheFollowOffsetValue();
				this.TrySetUseItemUiActive(true);
				this.HandleMoveInstantly();
			}
			this.UpdateCursorItemAttachParent();
		}

		// Token: 0x060330AB RID: 209067 RVA: 0x00CC8A47 File Offset: 0x00CC6C47
		public void RepeatMove()
		{
			this.IsNeedMove = true;
			this.MoveTickTime = 0f;
		}

		// Token: 0x060330AC RID: 209068 RVA: 0x00CC8A5C File Offset: 0x00CC6C5C
		private void CacheFollowOffsetValue()
		{
			float width = this.FollowItem.GetWidth();
			float height = this.FollowItem.GetHeight();
			int cursorRotation = this.Listener.GetCursorRotation();
			if (Cursor.TempWidth == width && Cursor.TempHeight == height && this.TempRotation == cursorRotation)
			{
				return;
			}
			FVector2D fvector2D = this.FollowItem.GetPivot();
			FVector fvector = fvector2D;
			fvector2D = this.Listener.GetCursorOffset();
			FVector fvector2 = fvector2D;
			fvector2D = this.Listener.GetBoundOffset();
			FVector fvector3 = fvector2D;
			float num = fvector2.X - Singleton<MathUtils>.Instance.Clamp(fvector.X, 0f, 1f);
			float num2 = fvector2.Y - Singleton<MathUtils>.Instance.Clamp(fvector.Y, 0f, 1f);
			Cursor.TempOffsetX = num * width + fvector3.X;
			Cursor.TempOffsetY = num2 * height + fvector3.Y;
			this.TempRotation = cursorRotation;
			Cursor.TempWidth = width;
			Cursor.TempHeight = height;
		}

		// Token: 0x060330AD RID: 209069 RVA: 0x00CC8B5C File Offset: 0x00CC6D5C
		private void UpdateCursorAlpha()
		{
			if (this.IsUseItemActive)
			{
				this.UseItem.SetAlpha(this.FollowItem.GetCalculatedParentAlpha());
			}
		}

		// Token: 0x060330AE RID: 209070 RVA: 0x00CC8B7C File Offset: 0x00CC6D7C
		public void SetIsUseMouse(bool value)
		{
			if (this.IsUseMouse == value)
			{
				return;
			}
			this.IsUseMouse = value;
			UUIItem followItem = this.FollowItem;
			bool value2 = followItem != null && followItem.bIsUIActive;
			this.TrySetUseItemUiActive(value2);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputChange]使用鼠标标记发生变更!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("使用鼠标", value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060330AF RID: 209071 RVA: 0x00CC8BE3 File Offset: 0x00CC6DE3
		private void HandleMoveInstantly()
		{
			if (this.IsMoveInstantly)
			{
				this.IsMoveInstantly = false;
				this.SetUseItemMoveInstantly();
				this.UpdateCursorAlpha();
			}
		}

		// Token: 0x060330B0 RID: 209072 RVA: 0x00CC8C00 File Offset: 0x00CC6E00
		private bool CheckMoveCondition()
		{
			if (!Singleton<UiManager>.Instance.IsInited)
			{
				return false;
			}
			this.RefreshUseItem();
			if (this.OriginalParentItem == null)
			{
				return false;
			}
			if (this.FollowItem == null || !this.FollowItem.IsValid())
			{
				return false;
			}
			if (this.Listener == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "光标, 找不到导航对象", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return this.IsNeedMove;
		}

		// Token: 0x060330B1 RID: 209073 RVA: 0x00CC8C78 File Offset: 0x00CC6E78
		private void HandleMove(float delta)
		{
			FVectorDouble fvectorDouble = this.FollowItem.D_K2_GetComponentLocation();
			FVector fvector = fvectorDouble;
			fvectorDouble = this.FollowItem.D_K2_GetComponentScale();
			FVector fvector2 = fvectorDouble;
			Cursor.TempFollowLocation.Set((double)(fvector.X + Cursor.TempOffsetX * fvector2.X), 0.0, (double)(fvector.Z + Cursor.TempOffsetY * fvector2.Y));
			Vector.Lerp(Cursor.TempLocation, Cursor.TempFollowLocation, (double)this.TotalSpeed, Cursor.TempThirdLocation);
			this.TotalSpeed += 0.05f;
			if (Vector.PointsAreSame(Cursor.TempThirdLocation, Cursor.TempFollowLocation))
			{
				Cursor.TempThirdLocation.DeepCopy(Cursor.TempFollowLocation);
				this.SetMoveTickTime();
			}
			Cursor.TempLocation.DeepCopy(Cursor.TempThirdLocation);
			this.CacheFollowOffsetValue();
			FHitResult fhitResult = new FHitResult();
			AActor owner = this.UseItem.GetOwner();
			owner.D_K2_SetActorLocation(Cursor.TempThirdLocation.ToUeVector(false), false, ref fhitResult, false);
			this.HandleRotationTransition(delta, owner);
		}

		// Token: 0x060330B2 RID: 209074 RVA: 0x00CC8D84 File Offset: 0x00CC6F84
		private void HandleRotationTransition(float delta, AActor useItemOwner)
		{
			int tempRotation = this.TempRotation;
			float calculatedParentAlpha = this.FollowItem.GetCalculatedParentAlpha();
			if (this.RotationTransitionRemaining == 0f)
			{
				if (Math.Abs(tempRotation - this.AppliedRotation) <= 1)
				{
					this.UpdateCursorAlpha();
					return;
				}
				this.RotationTransitionRemaining = 0.2f;
			}
			this.RotationTransitionRemaining -= delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			float num = 0.1f;
			if (this.RotationTransitionRemaining > num)
			{
				float num2 = (num * 2f - this.RotationTransitionRemaining) / num;
				this.UseItem.SetAlpha(calculatedParentAlpha * (1f - num2));
				return;
			}
			if (Math.Abs(tempRotation - this.AppliedRotation) > 1)
			{
				this.AppliedRotation = tempRotation;
				Cursor.TempRotator.DeepCopy(Cursor.OriRotator);
				Cursor.TempRotator.Pitch += (float)tempRotation;
				useItemOwner.K2_SetActorRotation(Cursor.TempRotator.ToUeRotator(), false);
			}
			if (this.RotationTransitionRemaining > 0f)
			{
				float num3 = (num - this.RotationTransitionRemaining) / num;
				this.UseItem.SetAlpha(calculatedParentAlpha * num3);
				return;
			}
			this.UseItem.SetAlpha(calculatedParentAlpha);
			this.RotationTransitionRemaining = 0f;
		}

		// Token: 0x060330B3 RID: 209075 RVA: 0x00CC8EAF File Offset: 0x00CC70AF
		public void Tick(float delta)
		{
			if (this.CheckMoveCondition())
			{
				this.HandleMove(delta);
				this.TickMoveTickTime(delta);
			}
		}

		// Token: 0x060330B4 RID: 209076 RVA: 0x00CC8EC8 File Offset: 0x00CC70C8
		public void Clear()
		{
			Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.AsyncLoadId);
			if (this.OriginalParentItem != null && this.OriginalParentItem.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("Cursor.Clear1", this.OriginalParentItem.GetOwner(), null);
			}
			if (this.UseItem != null && this.UseItem.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("Cursor.Clear2", this.UseItem.GetOwner(), null);
			}
			this.RemoveCursorActiveHandle();
			this.AsyncLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;
			this.CursorActiveDelayTime = 0f;
			this.OriginalParentItem = null;
			this.OriginalItem = null;
			this.UseItem = null;
			this.FollowItem = null;
			this.Listener = null;
			this.IsNeedMove = false;
			this.TotalSpeed = 0f;
			this.RotationTransitionRemaining = 0f;
			this.AppliedRotation = 0;
		}

		// Token: 0x060330B5 RID: 209077 RVA: 0x00CC8FAF File Offset: 0x00CC71AF
		private void SetMoveTickTime()
		{
			if (this.MoveTickTime <= 0f)
			{
				this.MoveTickTime = 2000f;
			}
		}

		// Token: 0x060330B6 RID: 209078 RVA: 0x00CC8FC9 File Offset: 0x00CC71C9
		private void TickMoveTickTime(float delta)
		{
			if (this.MoveTickTime <= 0f)
			{
				return;
			}
			this.MoveTickTime -= delta;
			if (this.MoveTickTime <= 0f)
			{
				this.IsNeedMove = false;
			}
		}

		// Token: 0x060330B7 RID: 209079 RVA: 0x00CC8FFC File Offset: 0x00CC71FC
		public void TrySetUseItemUiActive(bool value)
		{
			if (this.UseItem == null)
			{
				return;
			}
			if (!this.UseItem.IsValid())
			{
				return;
			}
			bool flag = value && this.IsCursorOpen && !this.IsUseMouse;
			if (this.IsUseItemActive == flag)
			{
				return;
			}
			this.RemoveCursorActiveHandle();
			this.IsUseItemActive = flag;
			if (!flag)
			{
				this.SetUseItemUiActive(flag);
				return;
			}
			this.AddCursorActiveHandle();
		}

		// Token: 0x060330B8 RID: 209080 RVA: 0x00CC9060 File Offset: 0x00CC7260
		private void SetUseItemUiActive(bool active)
		{
			this.UseItem.SetUIActive(active);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputChange]鼠标显隐发生变更!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("active", this.IsUseItemActive);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060330B9 RID: 209081 RVA: 0x00CC90B0 File Offset: 0x00CC72B0
		private void AddCursorActiveHandle()
		{
			if (this.CursorActiveDelayTime == 0f)
			{
				this.SetUseItemUiActive(true);
				return;
			}
			this.SetUseItemUiActive(false);
			this.CursorActiveHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float delta)
			{
				this.CursorActiveHandle = null;
				this.SetUseItemUiActive(true);
			}, this.CursorActiveDelayTime, null, null, true, 1f);
			this.CursorActiveDelayTime = 0f;
		}

		// Token: 0x060330BA RID: 209082 RVA: 0x00CC910E File Offset: 0x00CC730E
		private void RemoveCursorActiveHandle()
		{
			if (this.CursorActiveHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CursorActiveHandle);
				this.CursorActiveHandle = null;
			}
		}

		// Token: 0x060330BB RID: 209083 RVA: 0x00CC9130 File Offset: 0x00CC7330
		public void SetCursorActiveDelayTime(float time)
		{
			this.CursorActiveDelayTime = time;
		}

		// Token: 0x060330BC RID: 209084 RVA: 0x00CC9139 File Offset: 0x00CC7339
		public void RefreshCursorActive()
		{
			if (this.Listener == null)
			{
				return;
			}
			this.IsCursorOpen = this.Listener.Cursor.Switch;
			this.TrySetUseItemUiActive(true);
		}

		// Token: 0x060330BD RID: 209085 RVA: 0x00CC9161 File Offset: 0x00CC7361
		public static void CreateStaticDefaultValue()
		{
			Cursor._tempLocation = Vector.Create();
			Cursor._tempFollowLocation = Vector.Create();
			Cursor._tempThirdLocation = Vector.Create();
		}

		// Token: 0x060330BE RID: 209086 RVA: 0x00CC9184 File Offset: 0x00CC7384
		public static void ResetStaticDefaultValue()
		{
			Cursor.TempOffsetX = 0f;
			Cursor.TempOffsetY = 0f;
			Cursor.TempWidth = 0f;
			Cursor.TempHeight = 0f;
			Cursor._tempLocation = null;
			Cursor._tempFollowLocation = null;
			Cursor._tempThirdLocation = null;
			Cursor._tempRotator = null;
			Cursor._oriRotator = null;
		}

		// Token: 0x0401DADD RID: 121565
		public const float SPEED = 0.05f;

		// Token: 0x0401DADE RID: 121566
		public const float ALLOW_MOVE_TICK_LIMIT = 2000f;

		// Token: 0x0401DADF RID: 121567
		[Nullable(2)]
		private UUIItem OriginalParentItem;

		// Token: 0x0401DAE0 RID: 121568
		[Nullable(2)]
		private UUIItem OriginalItem;

		// Token: 0x0401DAE1 RID: 121569
		[Nullable(2)]
		private UUIItem UseItem;

		// Token: 0x0401DAE2 RID: 121570
		[Nullable(2)]
		private UUIItem FollowItem;

		// Token: 0x0401DAE3 RID: 121571
		[Nullable(2)]
		private TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DAE4 RID: 121572
		private int AsyncLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;

		// Token: 0x0401DAE5 RID: 121573
		private float TotalSpeed;

		// Token: 0x0401DAE6 RID: 121574
		private bool IsNeedMove;

		// Token: 0x0401DAE7 RID: 121575
		private bool IsCursorOpen = true;

		// Token: 0x0401DAE8 RID: 121576
		private bool IsUseMouse;

		// Token: 0x0401DAE9 RID: 121577
		private bool IsInFloat;

		// Token: 0x0401DAEA RID: 121578
		private float RotationTransitionRemaining;

		// Token: 0x0401DAEB RID: 121579
		private int AppliedRotation;

		// Token: 0x0401DAEC RID: 121580
		public bool IsMoveInstantly;

		// Token: 0x0401DAED RID: 121581
		[Nullable(2)]
		private static Vector _tempLocation;

		// Token: 0x0401DAEE RID: 121582
		[Nullable(2)]
		private static Rotator _oriRotator;

		// Token: 0x0401DAEF RID: 121583
		[Nullable(2)]
		private static Rotator _tempRotator;

		// Token: 0x0401DAF0 RID: 121584
		[Nullable(2)]
		private static Vector _tempFollowLocation;

		// Token: 0x0401DAF1 RID: 121585
		private static float TempOffsetX;

		// Token: 0x0401DAF2 RID: 121586
		private static float TempOffsetY;

		// Token: 0x0401DAF3 RID: 121587
		private int TempRotation;

		// Token: 0x0401DAF4 RID: 121588
		[Nullable(2)]
		private static Vector _tempThirdLocation;

		// Token: 0x0401DAF5 RID: 121589
		private static float TempWidth;

		// Token: 0x0401DAF6 RID: 121590
		private static float TempHeight;

		// Token: 0x0401DAF7 RID: 121591
		private float MoveTickTime;

		// Token: 0x0401DAF8 RID: 121592
		[Nullable(2)]
		private TimerHandle CursorActiveHandle;

		// Token: 0x0401DAF9 RID: 121593
		private bool IsUseItemActive;

		// Token: 0x0401DAFA RID: 121594
		private float CursorActiveDelayTime;
	}
}
