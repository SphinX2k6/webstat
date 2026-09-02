using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060EA RID: 24810
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarXigelika : SpecialEnergyBarBase
	{
		// Token: 0x0603EAC5 RID: 256709 RVA: 0x0100AE84 File Offset: 0x01009084
		protected override void OnRegisterComponent()
		{
			Dictionary<int, Type> dictionary = new Dictionary<int, Type>
			{
				{
					9,
					typeof(UUISprite)
				},
				{
					10,
					typeof(UUISprite)
				},
				{
					11,
					typeof(UUISprite)
				}
			};
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 28; i++)
			{
				Type type;
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, dictionary.TryGetValue(i, out type) ? type : typeof(UUIItem)));
			}
		}

		// Token: 0x0603EAC6 RID: 256710 RVA: 0x0100AF10 File Offset: 0x01009110
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarXigelika.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarXigelika.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAC7 RID: 256711 RVA: 0x0100AF54 File Offset: 0x01009154
		protected UniTask InitBarItem1()
		{
			SpecialEnergyBarXigelika.<InitBarItem1>d__22 <InitBarItem1>d__;
			<InitBarItem1>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem1>d__.<>4__this = this;
			<InitBarItem1>d__.<>1__state = -1;
			<InitBarItem1>d__.<>t__builder.Start<SpecialEnergyBarXigelika.<InitBarItem1>d__22>(ref <InitBarItem1>d__);
			return <InitBarItem1>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAC8 RID: 256712 RVA: 0x0100AF98 File Offset: 0x01009198
		private void SwitchBarButton()
		{
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.信心值Max"]))
			{
				SpecialEnergyBarXigelikaSlot barSlot = this.BarSlot;
				if (barSlot == null)
				{
					return;
				}
				barSlot.SwitchKeyItem(this.ConfigList[1]);
				return;
			}
			else
			{
				SpecialEnergyBarXigelikaSlot barSlot2 = this.BarSlot;
				if (barSlot2 == null)
				{
					return;
				}
				barSlot2.SwitchKeyItem(this.ConfigList[0]);
				return;
			}
		}

		// Token: 0x0603EAC9 RID: 256713 RVA: 0x0100AFFC File Offset: 0x010091FC
		private void UpdateTagState(bool[] arr, int[] tagIds)
		{
			for (int i = 0; i < tagIds.Length; i++)
			{
				arr[i] = this.TagComponent.HasTag(tagIds[i]);
			}
		}

		// Token: 0x0603EACA RID: 256714 RVA: 0x0100B028 File Offset: 0x01009228
		protected unsafe override void OnStart()
		{
			for (int i = 1; i <= 8; i++)
			{
				this.RunneIconItems.Add(base.GetItem(i));
			}
			for (int j = 12; j <= 24; j++)
			{
				base.InitTweenAnim(j);
			}
			this.UpdateTagState(this.RunneIconDataA, SpecialEnergyBarXigelika.locTagA);
			this.UpdateTagState(this.RunneIconDataB, SpecialEnergyBarXigelika.locTagB);
			this.UpdateTagState(this.RunneHeadDataA, SpecialEnergyBarXigelika.locUsedTagA);
			this.UpdateTagState(this.RunneHeadDataB, SpecialEnergyBarXigelika.locUsedTagB);
			this.RefreshIcons();
			this.RefreshHeads();
			this.UpdateBarC();
			if (this.PercentMachine.GetCurPercent() == 0f)
			{
				BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = 23;
				tweenAnimPlayer.StopAllBut(list);
				this.TweenAnimPlayer.PlayTweenAnim(12);
			}
			this.SwitchBarButton();
		}

		// Token: 0x0603EACB RID: 256715 RVA: 0x0100B113 File Offset: 0x01009313
		private void RemoveNextFrameTimer()
		{
			if (this.NextFrameTimer != null && TimerSystem.GameplayTimeInstance.Has(this.NextFrameTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.NextFrameTimer);
			}
			this.NextFrameTimer = null;
		}

		// Token: 0x0603EACC RID: 256716 RVA: 0x0100B148 File Offset: 0x01009348
		private void BindCountTags(int[] tagIds, bool[] outResult, Action onChanged)
		{
			TTimerAction <>9__1;
			for (int i = 0; i < tagIds.Length; i++)
			{
				int index = i;
				base.ListenForTagAddOrRemoveChanged(tagIds[i], delegate(int tagId, bool exist)
				{
					outResult[index] = exist;
					if (!this.IsWaitingNextFrame)
					{
						this.IsWaitingNextFrame = true;
						SpecialEnergyBarXigelika <>4__this = this;
						TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
						TTimerAction action;
						if ((action = <>9__1) == null)
						{
							action = (<>9__1 = delegate(float delta)
							{
								this.IsWaitingNextFrame = false;
								this.RemoveNextFrameTimer();
								Action onChanged2 = onChanged;
								if (onChanged2 == null)
								{
									return;
								}
								onChanged2();
							});
						}
						<>4__this.NextFrameTimer = gameplayTimeInstance.Next(action, null, null);
					}
				});
			}
		}

		// Token: 0x0603EACD RID: 256717 RVA: 0x0100B1A8 File Offset: 0x010093A8
		protected override void AddEvents()
		{
			base.AddEvents();
			this.BindCountTags(SpecialEnergyBarXigelika.locTagA, this.RunneIconDataA, new Action(this.OnRefreshIcons));
			this.BindCountTags(SpecialEnergyBarXigelika.locTagB, this.RunneIconDataB, new Action(this.OnRefreshIcons));
			this.BindCountTags(SpecialEnergyBarXigelika.locUsedTagA, this.RunneHeadDataA, new Action(this.OnRefreshHeads));
			this.BindCountTags(SpecialEnergyBarXigelika.locUsedTagB, this.RunneHeadDataB, new Action(this.OnRefreshHeads));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnEnergyBxChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy3, new Action<EAttributeType, float, float>(this.OnEnergyCxChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy3Max, new Action<EAttributeType, float, float>(this.OnEnergyCxChanged));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.信心值Max"], delegate(int tagId, bool exist)
			{
				this.SwitchBarButton();
				if (!exist)
				{
					BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
					if (tweenAnimPlayer == null)
					{
						return;
					}
					tweenAnimPlayer.PlayTweenAnim(23);
				}
			});
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.速读"], new BaseTagComponent.TTagSwitchedCallback(this.MarkPlayTwoFx));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.复读"], new BaseTagComponent.TTagSwitchedCallback(this.MarkPlayTwoFx));
		}

		// Token: 0x0603EACE RID: 256718 RVA: 0x0100B2CE File Offset: 0x010094CE
		private void MarkPlayTwoFx(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				this.IsPlayTwoFx = true;
			}
		}

		// Token: 0x0603EACF RID: 256719 RVA: 0x0100B2DA File Offset: 0x010094DA
		private void OnEnergyBxChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshIcons();
			this.RefreshHeads();
		}

		// Token: 0x0603EAD0 RID: 256720 RVA: 0x0100B2E8 File Offset: 0x010094E8
		private void OnEnergyCxChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.UpdateBarC();
		}

		// Token: 0x0603EAD1 RID: 256721 RVA: 0x0100B2F0 File Offset: 0x010094F0
		private void OnRefreshIcons()
		{
			this.RefreshIcons();
			this.RefreshHeads();
		}

		// Token: 0x0603EAD2 RID: 256722 RVA: 0x0100B2FE File Offset: 0x010094FE
		private void OnRefreshHeads()
		{
			this.RefreshIcons();
			this.RefreshHeads();
		}

		// Token: 0x0603EAD3 RID: 256723 RVA: 0x0100B30C File Offset: 0x0100950C
		private void UpdateBarC()
		{
			float energyPercentC = this.GetEnergyPercentC();
			bool flag = energyPercentC <= 0.5f;
			float fillAmount = flag ? (energyPercentC * 2f) : ((energyPercentC - 0.5f) * 2f);
			base.GetSprite(10).SetUIActive(!flag);
			if (flag)
			{
				base.GetSprite(9).SetFillAmount(fillAmount);
			}
			else
			{
				base.GetSprite(9).SetFillAmount(1f);
				base.GetSprite(10).SetFillAmount(fillAmount);
			}
			if (((double)energyPercentC < 0.5 && (double)this.LastPercentC == 0.5) || (energyPercentC < 1f && this.LastPercentC >= 1f))
			{
				base.PlayTweenAnim(24);
			}
			this.LastPercentC = energyPercentC;
		}

		// Token: 0x0603EAD4 RID: 256724 RVA: 0x0100B3D0 File Offset: 0x010095D0
		private float GetEnergyPercentB()
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2) : 0f;
			BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
			float num2 = (attributeComponent2 != null) ? attributeComponent2.GetCurrentValue(EAttributeType.SpecialEnergy2Max) : 0f;
			if (num2 <= 0f)
			{
				return 0f;
			}
			return num / num2;
		}

		// Token: 0x0603EAD5 RID: 256725 RVA: 0x0100B420 File Offset: 0x01009620
		private float GetEnergyPercentC()
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3) : 0f;
			BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
			float num2 = (attributeComponent2 != null) ? attributeComponent2.GetCurrentValue(EAttributeType.SpecialEnergy3Max) : 0f;
			if (num2 <= 0f)
			{
				return 0f;
			}
			return num / num2;
		}

		// Token: 0x0603EAD6 RID: 256726 RVA: 0x0100B470 File Offset: 0x01009670
		private void RefreshIcons()
		{
			bool[] runneIconDataA = this.RunneIconDataA;
			bool[] runneIconDataB = this.RunneIconDataB;
			bool[] runneHeadDataA = this.RunneHeadDataA;
			bool[] runneHeadDataB = this.RunneHeadDataB;
			bool flag = (runneIconDataA[0] || runneIconDataB[0]) && (runneIconDataA[1] || runneIconDataB[1]);
			bool flag2 = (runneIconDataA[2] || runneIconDataB[2]) && (runneIconDataA[3] || runneIconDataB[3]);
			bool flag3 = false;
			for (int i = 0; i < 4; i++)
			{
				int num = this.RunneIconState[i];
				int num2 = runneIconDataA[i] ? 0 : (runneIconDataB[i] ? 1 : -1);
				if ((i <= 1 && flag) || (i > 1 && flag2))
				{
					num2 += 2;
				}
				if (runneHeadDataA[i])
				{
					num2 = 4;
				}
				else if (runneHeadDataB[i])
				{
					num2 = 5;
				}
				if (num2 >= 0)
				{
					this.RunneIconItems[i * 2].SetUIActive(num2 % 2 == 0);
					this.RunneIconItems[i * 2 + 1].SetUIActive(num2 % 2 == 1);
					if (num < 0 && 0 <= num2 && num2 < 2)
					{
						BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
						if (tweenAnimPlayer != null)
						{
							tweenAnimPlayer.PlayTweenAnim(13 + i);
						}
					}
					bool flag4 = num != num2 && ((i == 0 && !flag) || (i == 2 && !flag2));
					bool flag5 = num != num2 && num < 2 && ((i == 0 && flag) || (i == 2 && flag2));
					bool flag6 = num != num2 && i % 2 == 0;
					bool flag7 = num != num2 && i % 2 == 1;
					bool flag8 = flag4 || flag5 || flag7 || flag3 || this.IsPlayTwoFx;
					flag3 = flag6;
					if (flag8 && num2 >= 2 && num2 <= 3)
					{
						BattleUiTweenAnimPlayer tweenAnimPlayer2 = this.TweenAnimPlayer;
						if (tweenAnimPlayer2 != null)
						{
							tweenAnimPlayer2.PlayTweenAnim(17 + i);
						}
					}
				}
				else
				{
					this.RunneIconItems[i * 2].SetUIActive(false);
					this.RunneIconItems[i * 2 + 1].SetUIActive(false);
				}
				this.RunneIconState[i] = num2;
			}
			this.IsPlayTwoFx = false;
		}

		// Token: 0x0603EAD7 RID: 256727 RVA: 0x0100B680 File Offset: 0x01009880
		private unsafe void RefreshHeads()
		{
			bool[] runneHeadDataA = this.RunneHeadDataA;
			bool[] runneHeadDataB = this.RunneHeadDataB;
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (runneHeadDataA[i] && runneHeadDataB[i])
				{
					Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.HWR, "西格莉卡能量条 日月灵都是已用状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				num += ((runneHeadDataA[i] || runneHeadDataB[i]) ? 1 : 0);
				SpecialEnergyBarXigelikaSlot barSlot = this.BarSlot;
				if (barSlot != null)
				{
					barSlot.SetSegmentVisible(i, !runneHeadDataA[i] && !runneHeadDataB[i]);
				}
			}
			float energyPercentB = this.GetEnergyPercentB();
			bool flag = (runneHeadDataA[0] || runneHeadDataB[0]) && (runneHeadDataA[1] || runneHeadDataB[1]) && energyPercentB >= 0.5f;
			bool flag2 = (runneHeadDataA[2] || runneHeadDataB[2]) && (runneHeadDataA[3] || runneHeadDataB[3]) && energyPercentB >= 1f;
			if (flag)
			{
				if (!this.RunneHeadState[0])
				{
					BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
					if (tweenAnimPlayer != null)
					{
						tweenAnimPlayer.PlayTweenAnim(21);
					}
					this.RunneHeadState[0] = true;
				}
			}
			else
			{
				this.RunneHeadState[0] = false;
			}
			if (flag2)
			{
				if (!this.RunneHeadState[1])
				{
					BattleUiTweenAnimPlayer tweenAnimPlayer2 = this.TweenAnimPlayer;
					if (tweenAnimPlayer2 != null)
					{
						tweenAnimPlayer2.PlayTweenAnim(22);
					}
					this.RunneHeadState[1] = true;
				}
			}
			else
			{
				this.RunneHeadState[1] = false;
			}
			base.GetItem(25).SetUIActive(flag || flag2);
			base.GetItem(26).SetUIActive(flag);
			base.GetItem(27).SetUIActive(flag2);
			if (num == 0 && this.ValidHeadCount > 0)
			{
				BattleUiTweenAnimPlayer tweenAnimPlayer3 = this.TweenAnimPlayer;
				if (tweenAnimPlayer3 != null)
				{
					int num2 = 1;
					List<int> list = new List<int>(num2);
					CollectionsMarshal.SetCount<int>(list, num2);
					Span<int> span = CollectionsMarshal.AsSpan<int>(list);
					int index = 0;
					*span[index] = 23;
					tweenAnimPlayer3.StopAllBut(list);
				}
				BattleUiTweenAnimPlayer tweenAnimPlayer4 = this.TweenAnimPlayer;
				if (tweenAnimPlayer4 != null)
				{
					tweenAnimPlayer4.PlayTweenAnim(12);
				}
			}
			this.ValidHeadCount = num;
		}

		// Token: 0x0603EAD8 RID: 256728 RVA: 0x0100B855 File Offset: 0x01009A55
		protected override void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(true);
			}
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603EAD9 RID: 256729 RVA: 0x0100B86F File Offset: 0x01009A6F
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarXigelikaSlot barSlot = this.BarSlot;
			if (barSlot == null)
			{
				return;
			}
			barSlot.Tick(delta);
		}

		// Token: 0x0603EADA RID: 256730 RVA: 0x0100B889 File Offset: 0x01009A89
		protected override void OnBeforeDestroy()
		{
			this.RunneIconItems.Clear();
			this.RemoveNextFrameTimer();
			base.OnBeforeDestroy();
		}

		// Token: 0x0402325A RID: 143962
		private const int BTN_E_CONFIG = 141201;

		// Token: 0x0402325B RID: 143963
		private const EAttributeType ENERGY_B_ATTR_ID = EAttributeType.SpecialEnergy2;

		// Token: 0x0402325C RID: 143964
		private const EAttributeType ENERGY_B_MAX_ATTR_ID = EAttributeType.SpecialEnergy2Max;

		// Token: 0x0402325D RID: 143965
		private const EAttributeType ENERGY_C_ATTR_ID = EAttributeType.SpecialEnergy3;

		// Token: 0x0402325E RID: 143966
		private const EAttributeType ENERGY_C_MAX_ATTR_ID = EAttributeType.SpecialEnergy3Max;

		// Token: 0x0402325F RID: 143967
		[StaticVariableRuleIgnore]
		private static readonly int[] locTagA = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记1"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记2"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记3"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记4"]
		};

		// Token: 0x04023260 RID: 143968
		[StaticVariableRuleIgnore]
		private static readonly int[] locTagB = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记1"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记2"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记3"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记4"]
		};

		// Token: 0x04023261 RID: 143969
		[StaticVariableRuleIgnore]
		private static readonly int[] locUsedTagA = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记1"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记2"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记3"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记4"]
		};

		// Token: 0x04023262 RID: 143970
		[StaticVariableRuleIgnore]
		private static readonly int[] locUsedTagB = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记1"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记2"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记3"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记4"]
		};

		// Token: 0x04023263 RID: 143971
		[Nullable(2)]
		private SpecialEnergyBarXigelikaSlot BarSlot;

		// Token: 0x04023264 RID: 143972
		private readonly bool[] RunneIconDataA = new bool[4];

		// Token: 0x04023265 RID: 143973
		private readonly bool[] RunneIconDataB = new bool[4];

		// Token: 0x04023266 RID: 143974
		private readonly int[] RunneIconState = new int[]
		{
			-1,
			-1,
			-1,
			-1
		};

		// Token: 0x04023267 RID: 143975
		private readonly bool[] RunneHeadDataA = new bool[4];

		// Token: 0x04023268 RID: 143976
		private readonly bool[] RunneHeadDataB = new bool[4];

		// Token: 0x04023269 RID: 143977
		private readonly bool[] RunneHeadState = new bool[2];

		// Token: 0x0402326A RID: 143978
		private readonly List<UUIItem> RunneIconItems = new List<UUIItem>();

		// Token: 0x0402326B RID: 143979
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x0402326C RID: 143980
		private int ValidHeadCount;

		// Token: 0x0402326D RID: 143981
		private bool IsWaitingNextFrame;

		// Token: 0x0402326E RID: 143982
		[Nullable(2)]
		private TimerHandle NextFrameTimer;

		// Token: 0x0402326F RID: 143983
		private bool IsPlayTwoFx;

		// Token: 0x04023270 RID: 143984
		private float LastPercentC;

		// Token: 0x0200C25A RID: 49754
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BE8C RID: 245388
			Slot4,
			// Token: 0x0403BE8D RID: 245389
			RunneIconAS,
			// Token: 0x0403BE8E RID: 245390
			RunneIconAM,
			// Token: 0x0403BE8F RID: 245391
			RunneIconBS,
			// Token: 0x0403BE90 RID: 245392
			RunneIconBM,
			// Token: 0x0403BE91 RID: 245393
			RunneIconCS,
			// Token: 0x0403BE92 RID: 245394
			RunneIconCM,
			// Token: 0x0403BE93 RID: 245395
			RunneIconDS,
			// Token: 0x0403BE94 RID: 245396
			RunneIconDM,
			// Token: 0x0403BE95 RID: 245397
			BuffBar1,
			// Token: 0x0403BE96 RID: 245398
			BuffBar2,
			// Token: 0x0403BE97 RID: 245399
			BuffLightBar,
			// Token: 0x0403BE98 RID: 245400
			AniReset,
			// Token: 0x0403BE99 RID: 245401
			AniRuneA,
			// Token: 0x0403BE9A RID: 245402
			AniRuneB,
			// Token: 0x0403BE9B RID: 245403
			AniRuneC,
			// Token: 0x0403BE9C RID: 245404
			AniRuneD,
			// Token: 0x0403BE9D RID: 245405
			AniActiveA,
			// Token: 0x0403BE9E RID: 245406
			AniActiveB,
			// Token: 0x0403BE9F RID: 245407
			AniActiveC,
			// Token: 0x0403BEA0 RID: 245408
			AniActiveD,
			// Token: 0x0403BEA1 RID: 245409
			AniTransL,
			// Token: 0x0403BEA2 RID: 245410
			AniTransR,
			// Token: 0x0403BEA3 RID: 245411
			AniEnhance,
			// Token: 0x0403BEA4 RID: 245412
			AniBarHLight,
			// Token: 0x0403BEA5 RID: 245413
			PnlActiveBg,
			// Token: 0x0403BEA6 RID: 245414
			SprFrameL,
			// Token: 0x0403BEA7 RID: 245415
			SprFrameR,
			// Token: 0x0403BEA8 RID: 245416
			MaxCount
		}
	}
}
