using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4C RID: 23628
	public class InfrastructureDefine
	{
		// Token: 0x040218FC RID: 137468
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, string> difficultySpriteResourceId = new Dictionary<int, string>
		{
			{
				1,
				"SP_InfrastructureMapStar1"
			},
			{
				2,
				"SP_InfrastructureMapStar2"
			},
			{
				3,
				"SP_InfrastructureMapStar3"
			}
		};

		// Token: 0x040218FD RID: 137469
		public const int MAX_INFR_MARK_INFO_LINE_NUM = 3;

		// Token: 0x040218FE RID: 137470
		public const int INFR_BATTLE_MATERIAL_ID = 80700001;

		// Token: 0x040218FF RID: 137471
		public const int INFR_COLLECTION_MATERIAL_ID = 80700002;

		// Token: 0x04021900 RID: 137472
		public const int INFR_QUEST_MATERIAL_ID = 80700003;

		// Token: 0x04021901 RID: 137473
		public const int INFR_SHOP_CURRENCY_ID = 80700004;

		// Token: 0x04021902 RID: 137474
		public const int INFR_OBSERVATORY_MARK_ID = 342011;

		// Token: 0x04021903 RID: 137475
		[Nullable(1)]
		public const string INFR_ACTIVITY_MALE_TEXTURE = "/Game/Aki/UI/UIResources/Common/Image/BgCgBig/Activity/Activity30/ActivityInfrastructure/ActivityMain/T_AcivityMainMale.T_AcivityMainMale";

		// Token: 0x04021904 RID: 137476
		[Nullable(1)]
		public const string INFR_ACTIVITY_FEMALE_TEXTURE = "/Game/Aki/UI/UIResources/Common/Image/BgCgBig/Activity/Activity30/ActivityInfrastructure/ActivityMain/T_AcivityMainFemale.T_AcivityMainFemale";

		// Token: 0x04021905 RID: 137477
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<InfrTaskStatusPb, EActivityRewardState> infrTaskStateToRewardStateResolver = new Dictionary<InfrTaskStatusPb, EActivityRewardState>
		{
			{
				InfrTaskStatusPb.InfrTaskRunning,
				EActivityRewardState.Disabled
			},
			{
				InfrTaskStatusPb.InfrTaskFinish,
				EActivityRewardState.Enable
			},
			{
				InfrTaskStatusPb.InfrTaskTaken,
				EActivityRewardState.Claimed
			}
		};

		// Token: 0x04021906 RID: 137478
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<InfrTaskStatusPb, string> infrTaskStateToRewardText = new Dictionary<InfrTaskStatusPb, string>
		{
			{
				InfrTaskStatusPb.InfrTaskRunning,
				"CollectActivity_state_open"
			},
			{
				InfrTaskStatusPb.InfrTaskFinish,
				"CollectActivity_state_CanRecive"
			},
			{
				InfrTaskStatusPb.InfrTaskTaken,
				"CollectActivity_state_recived"
			}
		};

		// Token: 0x04021907 RID: 137479
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, string> infrShopTabMenuName = new Dictionary<int, string>
		{
			{
				2,
				"BuildShop_Title_1"
			},
			{
				3,
				"BuildShop_Title_2"
			},
			{
				4,
				"BuildShop_Title_3"
			}
		};

		// Token: 0x0200BC9F RID: 48287
		public enum EMainMissionIndex
		{
			// Token: 0x0403A22F RID: 238127
			Quest,
			// Token: 0x0403A230 RID: 238128
			BuildTarget
		}

		// Token: 0x0200BCA0 RID: 48288
		public interface IInfrRoadData
		{
			// Token: 0x1700A9F6 RID: 43510
			// (get) Token: 0x0604DCEB RID: 318699
			// (set) Token: 0x0604DCEC RID: 318700
			int RoadId { get; set; }

			// Token: 0x1700A9F7 RID: 43511
			// (get) Token: 0x0604DCED RID: 318701
			// (set) Token: 0x0604DCEE RID: 318702
			InfrStatusPb Status { get; set; }

			// Token: 0x1700A9F8 RID: 43512
			// (get) Token: 0x0604DCEF RID: 318703
			// (set) Token: 0x0604DCF0 RID: 318704
			int CompleteTime { get; set; }

			// Token: 0x1700A9F9 RID: 43513
			// (get) Token: 0x0604DCF1 RID: 318705
			// (set) Token: 0x0604DCF2 RID: 318706
			int TotalGiftCount { get; set; }

			// Token: 0x1700A9FA RID: 43514
			// (get) Token: 0x0604DCF3 RID: 318707
			// (set) Token: 0x0604DCF4 RID: 318708
			int LastGiftTime { get; set; }
		}

		// Token: 0x0200BCA1 RID: 48289
		public class InfrRoadData : InfrastructureDefine.IInfrRoadData
		{
			// Token: 0x1700A9FB RID: 43515
			// (get) Token: 0x0604DCF5 RID: 318709 RVA: 0x0157E4AE File Offset: 0x0157C6AE
			// (set) Token: 0x0604DCF6 RID: 318710 RVA: 0x0157E4B6 File Offset: 0x0157C6B6
			public int RoadId { get; set; }

			// Token: 0x1700A9FC RID: 43516
			// (get) Token: 0x0604DCF7 RID: 318711 RVA: 0x0157E4BF File Offset: 0x0157C6BF
			// (set) Token: 0x0604DCF8 RID: 318712 RVA: 0x0157E4C7 File Offset: 0x0157C6C7
			public InfrStatusPb Status { get; set; }

			// Token: 0x1700A9FD RID: 43517
			// (get) Token: 0x0604DCF9 RID: 318713 RVA: 0x0157E4D0 File Offset: 0x0157C6D0
			// (set) Token: 0x0604DCFA RID: 318714 RVA: 0x0157E4D8 File Offset: 0x0157C6D8
			public int CompleteTime { get; set; }

			// Token: 0x1700A9FE RID: 43518
			// (get) Token: 0x0604DCFB RID: 318715 RVA: 0x0157E4E1 File Offset: 0x0157C6E1
			// (set) Token: 0x0604DCFC RID: 318716 RVA: 0x0157E4E9 File Offset: 0x0157C6E9
			public int TotalGiftCount { get; set; }

			// Token: 0x1700A9FF RID: 43519
			// (get) Token: 0x0604DCFD RID: 318717 RVA: 0x0157E4F2 File Offset: 0x0157C6F2
			// (set) Token: 0x0604DCFE RID: 318718 RVA: 0x0157E4FA File Offset: 0x0157C6FA
			public int LastGiftTime { get; set; }
		}

		// Token: 0x0200BCA2 RID: 48290
		public interface IInfrLibraryTaskData
		{
			// Token: 0x1700AA00 RID: 43520
			// (get) Token: 0x0604DD00 RID: 318720
			// (set) Token: 0x0604DD01 RID: 318721
			int TaskId { get; set; }

			// Token: 0x1700AA01 RID: 43521
			// (get) Token: 0x0604DD02 RID: 318722
			// (set) Token: 0x0604DD03 RID: 318723
			int Target { get; set; }

			// Token: 0x1700AA02 RID: 43522
			// (get) Token: 0x0604DD04 RID: 318724
			// (set) Token: 0x0604DD05 RID: 318725
			InfrTaskStatusPb Status { get; set; }
		}

		// Token: 0x0200BCA3 RID: 48291
		public class InfrLibraryTaskData : InfrastructureDefine.IInfrLibraryTaskData
		{
			// Token: 0x1700AA03 RID: 43523
			// (get) Token: 0x0604DD06 RID: 318726 RVA: 0x0157E50B File Offset: 0x0157C70B
			// (set) Token: 0x0604DD07 RID: 318727 RVA: 0x0157E513 File Offset: 0x0157C713
			public int TaskId { get; set; }

			// Token: 0x1700AA04 RID: 43524
			// (get) Token: 0x0604DD08 RID: 318728 RVA: 0x0157E51C File Offset: 0x0157C71C
			// (set) Token: 0x0604DD09 RID: 318729 RVA: 0x0157E524 File Offset: 0x0157C724
			public int Target { get; set; }

			// Token: 0x1700AA05 RID: 43525
			// (get) Token: 0x0604DD0A RID: 318730 RVA: 0x0157E52D File Offset: 0x0157C72D
			// (set) Token: 0x0604DD0B RID: 318731 RVA: 0x0157E535 File Offset: 0x0157C735
			public InfrTaskStatusPb Status { get; set; }
		}

		// Token: 0x0200BCA4 RID: 48292
		public interface IInfrMaterialsDeliveryOpenParam
		{
			// Token: 0x1700AA06 RID: 43526
			// (get) Token: 0x0604DD0D RID: 318733
			// (set) Token: 0x0604DD0E RID: 318734
			InfrastructureDefine.EMaterialDeliveryOpenSource OpenSource { get; set; }

			// Token: 0x1700AA07 RID: 43527
			// (get) Token: 0x0604DD0F RID: 318735
			// (set) Token: 0x0604DD10 RID: 318736
			ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA08 RID: 43528
			// (get) Token: 0x0604DD11 RID: 318737
			// (set) Token: 0x0604DD12 RID: 318738
			int RoadId { get; set; }

			// Token: 0x1700AA09 RID: 43529
			// (get) Token: 0x0604DD13 RID: 318739
			// (set) Token: 0x0604DD14 RID: 318740
			int? ActionId { get; set; }
		}

		// Token: 0x0200BCA5 RID: 48293
		public class InfrMaterialsDeliveryOpenParam : InfrastructureDefine.IInfrMaterialsDeliveryOpenParam
		{
			// Token: 0x1700AA0A RID: 43530
			// (get) Token: 0x0604DD15 RID: 318741 RVA: 0x0157E546 File Offset: 0x0157C746
			// (set) Token: 0x0604DD16 RID: 318742 RVA: 0x0157E54E File Offset: 0x0157C74E
			public InfrastructureDefine.EMaterialDeliveryOpenSource OpenSource { get; set; }

			// Token: 0x1700AA0B RID: 43531
			// (get) Token: 0x0604DD17 RID: 318743 RVA: 0x0157E557 File Offset: 0x0157C757
			// (set) Token: 0x0604DD18 RID: 318744 RVA: 0x0157E55F File Offset: 0x0157C75F
			public ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA0C RID: 43532
			// (get) Token: 0x0604DD19 RID: 318745 RVA: 0x0157E568 File Offset: 0x0157C768
			// (set) Token: 0x0604DD1A RID: 318746 RVA: 0x0157E570 File Offset: 0x0157C770
			public int RoadId { get; set; }

			// Token: 0x1700AA0D RID: 43533
			// (get) Token: 0x0604DD1B RID: 318747 RVA: 0x0157E579 File Offset: 0x0157C779
			// (set) Token: 0x0604DD1C RID: 318748 RVA: 0x0157E581 File Offset: 0x0157C781
			public int? ActionId { get; set; }
		}

		// Token: 0x0200BCA6 RID: 48294
		[NullableContext(1)]
		public interface IInfrRoadNetworkInfoOpenParam
		{
			// Token: 0x1700AA0E RID: 43534
			// (get) Token: 0x0604DD1E RID: 318750
			// (set) Token: 0x0604DD1F RID: 318751
			InfrastructureDefine.IInfrMaterialsDeliveryOpenParam InfoParam { get; set; }

			// Token: 0x1700AA0F RID: 43535
			// (get) Token: 0x0604DD20 RID: 318752
			// (set) Token: 0x0604DD21 RID: 318753
			Action BuildCb { get; set; }

			// Token: 0x1700AA10 RID: 43536
			// (get) Token: 0x0604DD22 RID: 318754
			// (set) Token: 0x0604DD23 RID: 318755
			Action CloseCb { get; set; }
		}

		// Token: 0x0200BCA7 RID: 48295
		[NullableContext(1)]
		[Nullable(0)]
		public class InfrRoadNetworkInfoOpenParam : InfrastructureDefine.IInfrRoadNetworkInfoOpenParam
		{
			// Token: 0x1700AA11 RID: 43537
			// (get) Token: 0x0604DD24 RID: 318756 RVA: 0x0157E592 File Offset: 0x0157C792
			// (set) Token: 0x0604DD25 RID: 318757 RVA: 0x0157E59A File Offset: 0x0157C79A
			public InfrastructureDefine.IInfrMaterialsDeliveryOpenParam InfoParam { get; set; }

			// Token: 0x1700AA12 RID: 43538
			// (get) Token: 0x0604DD26 RID: 318758 RVA: 0x0157E5A3 File Offset: 0x0157C7A3
			// (set) Token: 0x0604DD27 RID: 318759 RVA: 0x0157E5AB File Offset: 0x0157C7AB
			public Action BuildCb { get; set; }

			// Token: 0x1700AA13 RID: 43539
			// (get) Token: 0x0604DD28 RID: 318760 RVA: 0x0157E5B4 File Offset: 0x0157C7B4
			// (set) Token: 0x0604DD29 RID: 318761 RVA: 0x0157E5BC File Offset: 0x0157C7BC
			public Action CloseCb { get; set; }
		}

		// Token: 0x0200BCA8 RID: 48296
		public interface IInfrRoadNetworkOpenParam
		{
			// Token: 0x1700AA14 RID: 43540
			// (get) Token: 0x0604DD2B RID: 318763
			// (set) Token: 0x0604DD2C RID: 318764
			ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA15 RID: 43541
			// (get) Token: 0x0604DD2D RID: 318765
			// (set) Token: 0x0604DD2E RID: 318766
			int RoadId { get; set; }

			// Token: 0x1700AA16 RID: 43542
			// (get) Token: 0x0604DD2F RID: 318767
			// (set) Token: 0x0604DD30 RID: 318768
			bool? NeedPlayFinishSeq { get; set; }
		}

		// Token: 0x0200BCA9 RID: 48297
		public class InfrRoadNetworkOpenParam : InfrastructureDefine.IInfrRoadNetworkOpenParam
		{
			// Token: 0x1700AA17 RID: 43543
			// (get) Token: 0x0604DD31 RID: 318769 RVA: 0x0157E5CD File Offset: 0x0157C7CD
			// (set) Token: 0x0604DD32 RID: 318770 RVA: 0x0157E5D5 File Offset: 0x0157C7D5
			public ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA18 RID: 43544
			// (get) Token: 0x0604DD33 RID: 318771 RVA: 0x0157E5DE File Offset: 0x0157C7DE
			// (set) Token: 0x0604DD34 RID: 318772 RVA: 0x0157E5E6 File Offset: 0x0157C7E6
			public int RoadId { get; set; }

			// Token: 0x1700AA19 RID: 43545
			// (get) Token: 0x0604DD35 RID: 318773 RVA: 0x0157E5EF File Offset: 0x0157C7EF
			// (set) Token: 0x0604DD36 RID: 318774 RVA: 0x0157E5F7 File Offset: 0x0157C7F7
			public bool? NeedPlayFinishSeq { get; set; }
		}

		// Token: 0x0200BCAA RID: 48298
		public interface IInfrSettleViewOpenParam
		{
			// Token: 0x1700AA1A RID: 43546
			// (get) Token: 0x0604DD38 RID: 318776
			// (set) Token: 0x0604DD39 RID: 318777
			ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA1B RID: 43547
			// (get) Token: 0x0604DD3A RID: 318778
			// (set) Token: 0x0604DD3B RID: 318779
			int RoadId { get; set; }
		}

		// Token: 0x0200BCAB RID: 48299
		public class InfrSettleViewOpenParam : InfrastructureDefine.IInfrSettleViewOpenParam
		{
			// Token: 0x1700AA1C RID: 43548
			// (get) Token: 0x0604DD3C RID: 318780 RVA: 0x0157E608 File Offset: 0x0157C808
			// (set) Token: 0x0604DD3D RID: 318781 RVA: 0x0157E610 File Offset: 0x0157C810
			public ActionInfrastructureItemDeliveryType DeliveryType { get; set; }

			// Token: 0x1700AA1D RID: 43549
			// (get) Token: 0x0604DD3E RID: 318782 RVA: 0x0157E619 File Offset: 0x0157C819
			// (set) Token: 0x0604DD3F RID: 318783 RVA: 0x0157E621 File Offset: 0x0157C821
			public int RoadId { get; set; }
		}

		// Token: 0x0200BCAC RID: 48300
		[NullableContext(2)]
		public interface IInfrMainViewOpenParam
		{
			// Token: 0x1700AA1E RID: 43550
			// (get) Token: 0x0604DD41 RID: 318785
			// (set) Token: 0x0604DD42 RID: 318786
			bool NeedFocusBuildQuest { get; set; }

			// Token: 0x1700AA1F RID: 43551
			// (get) Token: 0x0604DD43 RID: 318787
			// (set) Token: 0x0604DD44 RID: 318788
			bool? NeedPlayBuildSuccessSeq { get; set; }

			// Token: 0x1700AA20 RID: 43552
			// (get) Token: 0x0604DD45 RID: 318789
			// (set) Token: 0x0604DD46 RID: 318790
			InfrastructureDefine.IInfrSettleViewOpenParam SettleInfo { get; set; }
		}

		// Token: 0x0200BCAD RID: 48301
		[NullableContext(2)]
		[Nullable(0)]
		public class InfrMainViewOpenParam : InfrastructureDefine.IInfrMainViewOpenParam
		{
			// Token: 0x1700AA21 RID: 43553
			// (get) Token: 0x0604DD47 RID: 318791 RVA: 0x0157E632 File Offset: 0x0157C832
			// (set) Token: 0x0604DD48 RID: 318792 RVA: 0x0157E63A File Offset: 0x0157C83A
			public bool NeedFocusBuildQuest { get; set; }

			// Token: 0x1700AA22 RID: 43554
			// (get) Token: 0x0604DD49 RID: 318793 RVA: 0x0157E643 File Offset: 0x0157C843
			// (set) Token: 0x0604DD4A RID: 318794 RVA: 0x0157E64B File Offset: 0x0157C84B
			public bool? NeedPlayBuildSuccessSeq { get; set; }

			// Token: 0x1700AA23 RID: 43555
			// (get) Token: 0x0604DD4B RID: 318795 RVA: 0x0157E654 File Offset: 0x0157C854
			// (set) Token: 0x0604DD4C RID: 318796 RVA: 0x0157E65C File Offset: 0x0157C85C
			public InfrastructureDefine.IInfrSettleViewOpenParam SettleInfo { get; set; }
		}

		// Token: 0x0200BCAE RID: 48302
		public interface IInfrShopOpenParam
		{
			// Token: 0x1700AA24 RID: 43556
			// (get) Token: 0x0604DD4E RID: 318798
			// (set) Token: 0x0604DD4F RID: 318799
			InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCAF RID: 48303
		public class InfrShopOpenParam : InfrastructureDefine.IInfrShopOpenParam
		{
			// Token: 0x1700AA25 RID: 43557
			// (get) Token: 0x0604DD50 RID: 318800 RVA: 0x0157E66D File Offset: 0x0157C86D
			// (set) Token: 0x0604DD51 RID: 318801 RVA: 0x0157E675 File Offset: 0x0157C875
			public InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCB0 RID: 48304
		public interface IInfrArchiveOpenParam
		{
			// Token: 0x1700AA26 RID: 43558
			// (get) Token: 0x0604DD53 RID: 318803
			// (set) Token: 0x0604DD54 RID: 318804
			InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCB1 RID: 48305
		public class InfrArchiveOpenParam : InfrastructureDefine.IInfrArchiveOpenParam
		{
			// Token: 0x1700AA27 RID: 43559
			// (get) Token: 0x0604DD55 RID: 318805 RVA: 0x0157E686 File Offset: 0x0157C886
			// (set) Token: 0x0604DD56 RID: 318806 RVA: 0x0157E68E File Offset: 0x0157C88E
			public InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCB2 RID: 48306
		public interface IInfrLimitTaskOpenParam
		{
			// Token: 0x1700AA28 RID: 43560
			// (get) Token: 0x0604DD58 RID: 318808
			// (set) Token: 0x0604DD59 RID: 318809
			InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCB3 RID: 48307
		public class InfrLimitTaskOpenParam : InfrastructureDefine.IInfrLimitTaskOpenParam
		{
			// Token: 0x1700AA29 RID: 43561
			// (get) Token: 0x0604DD5A RID: 318810 RVA: 0x0157E69F File Offset: 0x0157C89F
			// (set) Token: 0x0604DD5B RID: 318811 RVA: 0x0157E6A7 File Offset: 0x0157C8A7
			public InfrastructureDefine.EInfrViewOpenSource OpenSource { get; set; }
		}

		// Token: 0x0200BCB4 RID: 48308
		[NullableContext(1)]
		public interface IInfrMaterialsDeliveryLockData
		{
			// Token: 0x1700AA2A RID: 43562
			// (get) Token: 0x0604DD5D RID: 318813
			// (set) Token: 0x0604DD5E RID: 318814
			string LockDescriptionTextId { get; set; }

			// Token: 0x1700AA2B RID: 43563
			// (get) Token: 0x0604DD5F RID: 318815
			// (set) Token: 0x0604DD60 RID: 318816
			[Nullable(new byte[]
			{
				2,
				1
			})]
			string[] LockDescriptionTextArgs { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }
		}

		// Token: 0x0200BCB5 RID: 48309
		[NullableContext(1)]
		[Nullable(0)]
		public class InfrMaterialsDeliveryLockData : InfrastructureDefine.IInfrMaterialsDeliveryLockData
		{
			// Token: 0x1700AA2C RID: 43564
			// (get) Token: 0x0604DD61 RID: 318817 RVA: 0x0157E6B8 File Offset: 0x0157C8B8
			// (set) Token: 0x0604DD62 RID: 318818 RVA: 0x0157E6C0 File Offset: 0x0157C8C0
			public string LockDescriptionTextId { get; set; }

			// Token: 0x1700AA2D RID: 43565
			// (get) Token: 0x0604DD63 RID: 318819 RVA: 0x0157E6C9 File Offset: 0x0157C8C9
			// (set) Token: 0x0604DD64 RID: 318820 RVA: 0x0157E6D1 File Offset: 0x0157C8D1
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public string[] LockDescriptionTextArgs { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }
		}

		// Token: 0x0200BCB6 RID: 48310
		public class InfrNoticeData
		{
			// Token: 0x0403A24D RID: 238157
			public int RoadId;

			// Token: 0x0403A24E RID: 238158
			public int PasserId;

			// Token: 0x0403A24F RID: 238159
			public int GiftCount;

			// Token: 0x0403A250 RID: 238160
			public long CreateTime;
		}

		// Token: 0x0200BCB7 RID: 48311
		public enum EInfrArchiveTabType
		{
			// Token: 0x0403A252 RID: 238162
			CollectCard,
			// Token: 0x0403A253 RID: 238163
			RoleCard
		}

		// Token: 0x0200BCB8 RID: 48312
		public enum EMaterialDeliveryOpenSource
		{
			// Token: 0x0403A255 RID: 238165
			RoadNetworkMap,
			// Token: 0x0403A256 RID: 238166
			BigWorld
		}

		// Token: 0x0200BCB9 RID: 48313
		public enum EInfrViewOpenSource
		{
			// Token: 0x0403A258 RID: 238168
			Activity,
			// Token: 0x0403A259 RID: 238169
			Main,
			// Token: 0x0403A25A RID: 238170
			Delivery
		}
	}
}
