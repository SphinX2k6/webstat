using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006121 RID: 24865
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackedMarkForTower : TrackedMark
	{
		// Token: 0x0603ED0E RID: 257294 RVA: 0x0101774F File Offset: 0x0101594F
		public TrackedMarkForTower(ITrackData trackData) : base(trackData)
		{
		}

		// Token: 0x0603ED0F RID: 257295 RVA: 0x0101776E File Offset: 0x0101596E
		public override void Initialize(UUIItem parent)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_TowerBar", parent, true).Forget();
		}

		// Token: 0x0603ED10 RID: 257296 RVA: 0x01017784 File Offset: 0x01015984
		public override void OnUiShow()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				FVector fvector = new FVector(this.IsSubTrack ? 0.8f : 1f);
				rootItem.D_SetRelativeScale3D(fvector);
			}
			this.StopTweenAnim(6);
			this.PlayTweenAnim(4);
		}

		// Token: 0x0603ED11 RID: 257297 RVA: 0x010177D1 File Offset: 0x010159D1
		public override void OnUiHide()
		{
			this.StopTweenAnim(4);
			this.PlayTweenAnim(6);
		}

		// Token: 0x0603ED12 RID: 257298 RVA: 0x010177E4 File Offset: 0x010159E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ED13 RID: 257299 RVA: 0x010178F2 File Offset: 0x01015AF2
		protected override void OnStart()
		{
			this.DirectionComp = base.GetItem(1);
			this.DirectionComp.SetUIActive(!this.IsInTrackRange && !this.IsForceHideDirection);
			this.InitAllTweenAnim();
		}

		// Token: 0x0603ED14 RID: 257300 RVA: 0x01017926 File Offset: 0x01015B26
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.AttributeComponent = null;
			this.DisposeTweener();
			this.StopTweenAnim(4);
			this.StopTweenAnim(5);
			this.StopTweenAnim(6);
			this.TweenAnimMap.Clear();
		}

		// Token: 0x0603ED15 RID: 257301 RVA: 0x0101795C File Offset: 0x01015B5C
		public override void Update(float delta)
		{
			if (GlobalData.World == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LK, "【疑难杂症】标记固定在屏幕中心，GameWorld为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (Singleton<UiLayer>.Instance.UiRootItem == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LK, "【疑难杂症】标记固定在屏幕中心，RootItem为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.RootItem == null)
			{
				return;
			}
			this.CurShowTime += delta / 1000f;
			this.RootItem.SetUIActive(true);
			this.UpdatePositionAndRotation(delta);
			this.UpdateHealth();
		}

		// Token: 0x0603ED16 RID: 257302 RVA: 0x010179EC File Offset: 0x01015BEC
		protected override void UpdatePositionAndRotation(float delta)
		{
			TsCharacterController characterController = Global.CharacterController;
			FVectorDouble fvectorDouble = this.TempTrackPosition.ToUeVector(false);
			bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref this.ScreenPositionRef, false);
			if (!flag)
			{
				FTransformDouble value = ModelBase<CameraModel>.Instance.MainModel.CameraTransform.Value;
				FVectorDouble fvectorDouble2 = value.InverseTransformPositionNoScale(fvectorDouble);
				fvectorDouble2.X = -fvectorDouble2.X;
				FVectorDouble fvectorDouble3 = value.TransformPositionNoScale(fvectorDouble2);
				UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble3, ref this.ScreenPositionRef, false);
			}
			FVector2D screenPositionRef = this.ScreenPositionRef;
			this.ScreenPosition.Set((double)screenPositionRef.X, (double)screenPositionRef.Y);
			if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0) || this.NiagaraNeedActivateNextTick)
			{
				this.LastScreenPosition.DeepCopy(this.ScreenPosition);
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
				this.InRange = base.ClampToEllipse(this.ScreenPosition, flag);
				Vector2D vector2D = this.ScreenPosition.AdditionEqual(TrackDefine.center);
				this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
				if (!this.InRange && !this.IsInTrackRange && !this.IsForceHideDirection)
				{
					this.TempRotator.Reset();
					this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875 - 90.0);
					UUIItem directionComp = this.DirectionComp;
					FRotator frotator = this.TempRotator.ToUeRotator();
					directionComp.SetUIRelativeRotation(frotator);
					this.DirectionComp.SetUIActive(true);
					return;
				}
				this.DirectionComp.SetUIActive(false);
			}
		}

		// Token: 0x0603ED17 RID: 257303 RVA: 0x01017BC0 File Offset: 0x01015DC0
		private void UpdateHealth()
		{
			if (this.AttributeComponent == null)
			{
				TTrackTarget_Int ttrackTarget_Int = this.TrackTarget as TTrackTarget_Int;
				if (ttrackTarget_Int == null)
				{
					throw new InvalidCastException();
				}
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ttrackTarget_Int.Value);
				if (entityByPbDataId == null)
				{
					return;
				}
				WorldEntity entity = entityByPbDataId.Entity;
				if (entity == null)
				{
					return;
				}
				this.AttributeComponent = entity.GetComponent<BaseAttributeComponent>();
				if (this.AttributeComponent == null)
				{
					return;
				}
			}
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.Life);
			if (currentValue >= this.LastHp)
			{
				return;
			}
			float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
			float num = currentValue / currentValue2;
			base.GetSprite(0).SetFillAmount(num);
			this.PlayTweenAnim(5);
			float fillAmount = base.GetSprite(3).GetFillAmount();
			this.DisposeTweener();
			this.PlayTweener(fillAmount, num);
			this.LastHp = currentValue;
		}

		// Token: 0x0603ED18 RID: 257304 RVA: 0x01017C86 File Offset: 0x01015E86
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(4);
			this.InitTweenAnim(5);
			this.InitTweenAnim(6);
		}

		// Token: 0x0603ED19 RID: 257305 RVA: 0x01017CA0 File Offset: 0x01015EA0
		private void InitTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			foreach (UActorComponent uactorComponent in base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()))
			{
				ULGUIPlayTweenComponent ulguiplayTweenComponent = uactorComponent as ULGUIPlayTweenComponent;
				if (ulguiplayTweenComponent != null)
				{
					list.Add(ulguiplayTweenComponent);
				}
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603ED1A RID: 257306 RVA: 0x01017D20 File Offset: 0x01015F20
		private void PlayTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603ED1B RID: 257307 RVA: 0x01017D7C File Offset: 0x01015F7C
		private void StopTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x0603ED1C RID: 257308 RVA: 0x01017DD8 File Offset: 0x01015FD8
		private void DisposeTweener()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.SetChangeBar));
			ULTweener tweener = this.Tweener;
			if (tweener != null)
			{
				tweener.Kill(false);
			}
			this.Tweener = null;
			this.StopTweenAnim(5);
		}

		// Token: 0x0603ED1D RID: 257309 RVA: 0x01017E0C File Offset: 0x0101600C
		private void PlayTweener(float from, float to)
		{
			this.Tweener = ULTweenBPLibrary.FloatTo(this.RootActor, global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.SetChangeBar)), from, to, 0.5f, 0f, LTweenEase.OutCubic);
			this.Tweener.OnCompleteCallBack.Bind(new Action(this.DisposeTweener));
		}

		// Token: 0x0603ED1E RID: 257310 RVA: 0x01017E64 File Offset: 0x01016064
		private void SetChangeBar(float value)
		{
			base.GetSprite(2).SetFillAmount(value);
			base.GetSprite(3).SetFillAmount(value);
		}

		// Token: 0x040233E4 RID: 144356
		private const float SUB_SCALE = 0.8f;

		// Token: 0x040233E5 RID: 144357
		[Nullable(2)]
		private BaseAttributeComponent AttributeComponent;

		// Token: 0x040233E6 RID: 144358
		[Nullable(2)]
		private ULTweener Tweener;

		// Token: 0x040233E7 RID: 144359
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x040233E8 RID: 144360
		private float LastHp = float.MaxValue;

		// Token: 0x0200C2AC RID: 49836
		[NullableContext(0)]
		private enum EUiComponent
		{
			// Token: 0x0403C04F RID: 245839
			BarBaseSprite,
			// Token: 0x0403C050 RID: 245840
			DirectionItem,
			// Token: 0x0403C051 RID: 245841
			BarLightSprite,
			// Token: 0x0403C052 RID: 245842
			BarYellowSprite,
			// Token: 0x0403C053 RID: 245843
			AniStartItem,
			// Token: 0x0403C054 RID: 245844
			AniHitItem,
			// Token: 0x0403C055 RID: 245845
			AniCloseItem
		}
	}
}
