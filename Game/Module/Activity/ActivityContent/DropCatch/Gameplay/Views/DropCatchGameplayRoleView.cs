using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006911 RID: 26897
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayRoleView : UiPanelBase
	{
		// Token: 0x06042CC6 RID: 273606 RVA: 0x01124C2C File Offset: 0x01122E2C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06042CC7 RID: 273607 RVA: 0x01124CF4 File Offset: 0x01122EF4
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchGameplayRoleView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchGameplayRoleView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042CC8 RID: 273608 RVA: 0x01124D37 File Offset: 0x01122F37
		protected override void OnStart()
		{
		}

		// Token: 0x06042CC9 RID: 273609 RVA: 0x01124D39 File Offset: 0x01122F39
		private void UpdateBowlScaleX(float scaleX)
		{
			this.Scale.X = (double)scaleX;
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIItemScale(this.Scale.ToUeVectorOld());
		}

		// Token: 0x06042CCA RID: 273610 RVA: 0x01124D64 File Offset: 0x01122F64
		public void UpdateRolePos(Vector2D pos)
		{
			base.GetRootItem().SetAnchorOffset(pos.ToUeVector2D(false));
			Action<double> posChangeCallback = this.PosChangeCallback;
			if (posChangeCallback == null)
			{
				return;
			}
			posChangeCallback(pos.X);
		}

		// Token: 0x06042CCB RID: 273611 RVA: 0x01124D90 File Offset: 0x01122F90
		public void PlayAnimation(EDropCatchRoleAnimState state)
		{
			string animationName = this.StateToAnimName[state].ToEnumString();
			if ((this.OpenParam as IDropCatchGameplayRoleViewParams).RoleId == 3)
			{
				animationName = this.StateToMorningSpecialAnimName[state].ToEnumString();
			}
			USpineSkeletonAnimationComponent spine = base.GetSpine(0);
			if (spine != null)
			{
				spine.SetAnimation(0, animationName, true);
			}
			if (this.BowlStates.Contains(state))
			{
				USpineSkeletonAnimationComponent spine2 = base.GetSpine(3);
				if (spine2 != null)
				{
					spine2.SetAnimation(0, state.ToEnumString(), true);
				}
				this.UpdateBowlScaleX(this.BowlSpineScaleX);
			}
			else
			{
				this.UpdateBowlScaleX(0f);
			}
			this.UpdateFxOffset(state);
		}

		// Token: 0x06042CCC RID: 273612 RVA: 0x01124E33 File Offset: 0x01123033
		[NullableContext(2)]
		public DropCatchGameplayRoleFxView GetFxView()
		{
			return this.FxView;
		}

		// Token: 0x06042CCD RID: 273613 RVA: 0x01124E3C File Offset: 0x0112303C
		public UniTask CreateFxView()
		{
			DropCatchGameplayRoleView.<CreateFxView>d__17 <CreateFxView>d__;
			<CreateFxView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFxView>d__.<>4__this = this;
			<CreateFxView>d__.<>1__state = -1;
			<CreateFxView>d__.<>t__builder.Start<DropCatchGameplayRoleView.<CreateFxView>d__17>(ref <CreateFxView>d__);
			return <CreateFxView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CCE RID: 273614 RVA: 0x01124E80 File Offset: 0x01123080
		public UniTask RefreshSpine()
		{
			DropCatchGameplayRoleView.<RefreshSpine>d__18 <RefreshSpine>d__;
			<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSpine>d__.<>4__this = this;
			<RefreshSpine>d__.<>1__state = -1;
			<RefreshSpine>d__.<>t__builder.Start<DropCatchGameplayRoleView.<RefreshSpine>d__18>(ref <RefreshSpine>d__);
			return <RefreshSpine>d__.<>t__builder.Task;
		}

		// Token: 0x06042CCF RID: 273615 RVA: 0x01124EC4 File Offset: 0x011230C4
		public void UpdateFxOffset(EDropCatchRoleAnimState state)
		{
			if (this.LeftStates.Contains(state))
			{
				DropCatchGameplayRoleFxView fxView = this.FxView;
				if (fxView == null)
				{
					return;
				}
				fxView.GetRootItem().SetAnchorOffsetX((float)this.ROLE_FX_OFFSET);
				return;
			}
			else
			{
				DropCatchGameplayRoleFxView fxView2 = this.FxView;
				if (fxView2 == null)
				{
					return;
				}
				fxView2.GetRootItem().SetAnchorOffsetX((float)(-(float)this.ROLE_FX_OFFSET));
				return;
			}
		}

		// Token: 0x06042CD0 RID: 273616 RVA: 0x01124F1C File Offset: 0x0112311C
		public void SetChangeColor(bool useChangeColor, string hexColor, float? duration = null)
		{
			FColor color = FColor.FromHex(hexColor);
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				bool useChangeColor2 = useChangeColor;
				FColor? fcolor = new FColor?(color);
				item.SetChangeColor(useChangeColor2, fcolor);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				bool useChangeColor3 = useChangeColor;
				FColor? fcolor = new FColor?(color);
				item2.SetChangeColor(useChangeColor3, fcolor);
			}
			this.ClearTimer();
			if (duration == null)
			{
				return;
			}
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UUIItem item3 = this.GetItem(7);
				FColor? fcolor2;
				if (item3 != null)
				{
					bool bUseChangeColor = !useChangeColor;
					fcolor2 = new FColor?(color);
					item3.SetChangeColor(bUseChangeColor, fcolor2);
				}
				UUIItem item4 = this.GetItem(4);
				if (item4 == null)
				{
					return;
				}
				bool bUseChangeColor2 = !useChangeColor;
				fcolor2 = new FColor?(color);
				item4.SetChangeColor(bUseChangeColor2, fcolor2);
			}, duration.Value * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}

		// Token: 0x06042CD1 RID: 273617 RVA: 0x01124FDC File Offset: 0x011231DC
		private void ClearTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}

		// Token: 0x06042CD2 RID: 273618 RVA: 0x01125008 File Offset: 0x01123208
		protected override void OnBeforeHide()
		{
			DropCatchGameplayRoleFxView fxView = this.FxView;
			if (fxView == null)
			{
				return;
			}
			fxView.ResetView();
		}

		// Token: 0x06042CD3 RID: 273619 RVA: 0x0112501A File Offset: 0x0112321A
		protected override void OnBeforeDestroy()
		{
			this.ClearTimer();
		}

		// Token: 0x06042CD4 RID: 273620 RVA: 0x01125024 File Offset: 0x01123224
		private void UpdateDebugSize(float[] roleSizeBias, Tuple<float, float> roleSize, float[] bowlSizeBias, Tuple<float, float> bowlSize)
		{
			if (!ControllerBase<DropCatchGameplayController>.Instance.EnableDebug)
			{
				UUIItem item = base.GetItem(5);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(6);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item3 = base.GetItem(5);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(6);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(5);
				if (item5 != null)
				{
					item5.SetAnchorOffsetX(roleSizeBias[0]);
				}
				UUIItem item6 = base.GetItem(5);
				if (item6 != null)
				{
					item6.SetAnchorOffsetY(roleSizeBias[1]);
				}
				UUIItem item7 = base.GetItem(5);
				if (item7 != null)
				{
					item7.SetWidth(roleSize.Item1);
				}
				UUIItem item8 = base.GetItem(5);
				if (item8 != null)
				{
					item8.SetHeight(roleSize.Item2);
				}
				UUIItem item9 = base.GetItem(6);
				if (item9 != null)
				{
					item9.SetAnchorOffsetX(bowlSizeBias[0]);
				}
				UUIItem item10 = base.GetItem(6);
				if (item10 != null)
				{
					item10.SetAnchorOffsetY(bowlSizeBias[1]);
				}
				UUIItem item11 = base.GetItem(6);
				if (item11 != null)
				{
					item11.SetWidth(bowlSize.Item1);
				}
				UUIItem item12 = base.GetItem(6);
				if (item12 == null)
				{
					return;
				}
				item12.SetHeight(bowlSize.Item2);
				return;
			}
		}

		// Token: 0x04025395 RID: 152469
		private readonly int ROLE_FX_OFFSET = 12;

		// Token: 0x04025396 RID: 152470
		private readonly Dictionary<EDropCatchRoleAnimState, EDropCatchRoleAnimState> StateToAnimName = new Dictionary<EDropCatchRoleAnimState, EDropCatchRoleAnimState>
		{
			{
				EDropCatchRoleAnimState.IdleBowlLeft,
				EDropCatchRoleAnimState.IdleLeft
			},
			{
				EDropCatchRoleAnimState.IdleLeft,
				EDropCatchRoleAnimState.IdleLeft
			},
			{
				EDropCatchRoleAnimState.IdleBowlRight,
				EDropCatchRoleAnimState.IdleRight
			},
			{
				EDropCatchRoleAnimState.IdleRight,
				EDropCatchRoleAnimState.IdleRight
			},
			{
				EDropCatchRoleAnimState.WalkBowlLeft,
				EDropCatchRoleAnimState.WalkLeft
			},
			{
				EDropCatchRoleAnimState.WalkLeft,
				EDropCatchRoleAnimState.WalkLeft
			},
			{
				EDropCatchRoleAnimState.WalkBowlRight,
				EDropCatchRoleAnimState.WalkRight
			},
			{
				EDropCatchRoleAnimState.WalkRight,
				EDropCatchRoleAnimState.WalkRight
			}
		};

		// Token: 0x04025397 RID: 152471
		private readonly Dictionary<EDropCatchRoleAnimState, EMorningSpecialAnimState> StateToMorningSpecialAnimName = new Dictionary<EDropCatchRoleAnimState, EMorningSpecialAnimState>
		{
			{
				EDropCatchRoleAnimState.IdleBowlLeft,
				EMorningSpecialAnimState.IdleNothingLeft
			},
			{
				EDropCatchRoleAnimState.IdleLeft,
				EMorningSpecialAnimState.IdleNothingLeft
			},
			{
				EDropCatchRoleAnimState.IdleBowlRight,
				EMorningSpecialAnimState.IdleNothingRight
			},
			{
				EDropCatchRoleAnimState.IdleRight,
				EMorningSpecialAnimState.IdleNothingRight
			},
			{
				EDropCatchRoleAnimState.WalkBowlLeft,
				EMorningSpecialAnimState.WalkNothingLeft
			},
			{
				EDropCatchRoleAnimState.WalkLeft,
				EMorningSpecialAnimState.WalkNothingLeft
			},
			{
				EDropCatchRoleAnimState.WalkBowlRight,
				EMorningSpecialAnimState.WalkNothingRight
			},
			{
				EDropCatchRoleAnimState.WalkRight,
				EMorningSpecialAnimState.WalkNothingRight
			}
		};

		// Token: 0x04025398 RID: 152472
		private readonly HashSet<EDropCatchRoleAnimState> BowlStates = new HashSet<EDropCatchRoleAnimState>
		{
			EDropCatchRoleAnimState.IdleBowlLeft,
			EDropCatchRoleAnimState.IdleBowlRight,
			EDropCatchRoleAnimState.WalkBowlLeft,
			EDropCatchRoleAnimState.WalkBowlRight
		};

		// Token: 0x04025399 RID: 152473
		private readonly HashSet<EDropCatchRoleAnimState> LeftStates = new HashSet<EDropCatchRoleAnimState>
		{
			EDropCatchRoleAnimState.IdleLeft,
			EDropCatchRoleAnimState.IdleBowlLeft,
			EDropCatchRoleAnimState.WalkLeft,
			EDropCatchRoleAnimState.WalkBowlLeft
		};

		// Token: 0x0402539A RID: 152474
		[Nullable(2)]
		private DropCatchGameplayRoleFxView FxView;

		// Token: 0x0402539B RID: 152475
		[Nullable(2)]
		public Action<double> PosChangeCallback;

		// Token: 0x0402539C RID: 152476
		private float BowlSpineScaleX;

		// Token: 0x0402539D RID: 152477
		private readonly Vector Scale = Vector.Create(0.0, 0.32199999690055847, 0.32199999690055847);

		// Token: 0x0402539E RID: 152478
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
