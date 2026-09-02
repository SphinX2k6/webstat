using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Utils.CombatStateMachine
{
	// Token: 0x02004726 RID: 18214
	public class CombatStateMachineDefine
	{
		// Token: 0x0200A879 RID: 43129
		public static class Fsm
		{
			// Token: 0x0200CE4B RID: 52811
			public enum EFsmSyncKey
			{
				// Token: 0x0403F9BE RID: 260542
				RandomMontageIndex = 1,
				// Token: 0x0403F9BF RID: 260543
				MoveToTarget
			}

			// Token: 0x0200CE4C RID: 52812
			public enum ETaskType
			{
				// Token: 0x0403F9C1 RID: 260545
				TaskSkill = 1,
				// Token: 0x0403F9C2 RID: 260546
				TaskSkillByName,
				// Token: 0x0403F9C3 RID: 260547
				TaskRandomMontage,
				// Token: 0x0403F9C4 RID: 260548
				TaskLeaveFight = 101,
				// Token: 0x0403F9C5 RID: 260549
				TaskMontage,
				// Token: 0x0403F9C6 RID: 260550
				TaskMoveToTarget,
				// Token: 0x0403F9C7 RID: 260551
				TaskPatrol,
				// Token: 0x0403F9C8 RID: 260552
				TaskBeHitMontage,
				// Token: 0x0403F9C9 RID: 260553
				TaskGroupPatrol,
				// Token: 0x0403F9CA RID: 260554
				TaskGroupPerform
			}

			// Token: 0x0200CE4D RID: 52813
			[NullableContext(2)]
			[Nullable(0)]
			public class Task
			{
				// Token: 0x0403F9CB RID: 260555
				public int Type;

				// Token: 0x0403F9CC RID: 260556
				public bool CanBeInterrupt;

				// Token: 0x0403F9CD RID: 260557
				public CombatStateMachineDefine.Fsm.TaskSkill TaskSkill;

				// Token: 0x0403F9CE RID: 260558
				public CombatStateMachineDefine.Fsm.TaskSkillByName TaskSkillByName;

				// Token: 0x0403F9CF RID: 260559
				public CombatStateMachineDefine.Fsm.TaskRandomMontage TaskRandomMontage;

				// Token: 0x0403F9D0 RID: 260560
				public CombatStateMachineDefine.Fsm.TaskLeaveFight TaskLeaveFight;

				// Token: 0x0403F9D1 RID: 260561
				public CombatStateMachineDefine.Fsm.TaskMontage TaskMontage;

				// Token: 0x0403F9D2 RID: 260562
				public CombatStateMachineDefine.Fsm.TaskMoveToTarget TaskMoveToTarget;

				// Token: 0x0403F9D3 RID: 260563
				public CombatStateMachineDefine.Fsm.TaskPatrol TaskPatrol;

				// Token: 0x0403F9D4 RID: 260564
				public CombatStateMachineDefine.Fsm.TaskBeHitMontage TaskBeHitMontage;

				// Token: 0x0403F9D5 RID: 260565
				public CombatStateMachineDefine.Fsm.TaskGroupPatrol TaskGroupPatrol;

				// Token: 0x0403F9D6 RID: 260566
				public CombatStateMachineDefine.Fsm.TaskGroupPerform TaskGroupPerform;

				// Token: 0x0403F9D7 RID: 260567
				public string Name;
			}

			// Token: 0x0200CE4E RID: 52814
			public class TaskSkill
			{
				// Token: 0x0403F9D8 RID: 260568
				public int SkillId;

				// Token: 0x0403F9D9 RID: 260569
				public int ConfigReplaceTagId;

				// Token: 0x0403F9DA RID: 260570
				[Nullable(1)]
				public string ConfigReplaceTagName = "";
			}

			// Token: 0x0200CE4F RID: 52815
			[NullableContext(1)]
			[Nullable(0)]
			public class TaskSkillByName
			{
				// Token: 0x0403F9DB RID: 260571
				public string SkillName = "";

				// Token: 0x0403F9DC RID: 260572
				public int ConfigReplaceTagId;

				// Token: 0x0403F9DD RID: 260573
				public string ConfigReplaceTagName = "";
			}

			// Token: 0x0200CE50 RID: 52816
			public class TaskRandomMontage
			{
				// Token: 0x0403F9DE RID: 260574
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<string> MontageNames;

				// Token: 0x0403F9DF RID: 260575
				public bool HideOnLoading;

				// Token: 0x0403F9E0 RID: 260576
				public float BlendInTime;

				// Token: 0x0403F9E1 RID: 260577
				public bool RandomByClient;
			}

			// Token: 0x0200CE51 RID: 52817
			public class TaskLeaveFight
			{
				// Token: 0x0403F9E2 RID: 260578
				public float BlinkTime;

				// Token: 0x0403F9E3 RID: 260579
				public float MaxStopTime;

				// Token: 0x0403F9E4 RID: 260580
				public bool UsePatrolPointPriority;
			}

			// Token: 0x0200CE52 RID: 52818
			[NullableContext(1)]
			[Nullable(0)]
			public class TaskMontage
			{
				// Token: 0x0403F9E5 RID: 260581
				public string MontageName = "";

				// Token: 0x0403F9E6 RID: 260582
				public bool HideOnLoading;

				// Token: 0x0403F9E7 RID: 260583
				public float BlendInTime;

				// Token: 0x0403F9E8 RID: 260584
				public bool ForcePush2Server;

				// Token: 0x0403F9E9 RID: 260585
				public int ConfigReplaceTagId;

				// Token: 0x0403F9EA RID: 260586
				public string ConfigReplaceTagName = "";
			}

			// Token: 0x0200CE53 RID: 52819
			public class TaskMoveToTarget
			{
				// Token: 0x0403F9EB RID: 260587
				public int TargetType;

				// Token: 0x0403F9EC RID: 260588
				public int MoveState;

				// Token: 0x0403F9ED RID: 260589
				public float EndDistance;

				// Token: 0x0403F9EE RID: 260590
				public float TurnSpeed;

				// Token: 0x0403F9EF RID: 260591
				public bool WalkOff;
			}

			// Token: 0x0200CE54 RID: 52820
			public class TaskPatrol
			{
				// Token: 0x0403F9F0 RID: 260592
				public int MoveState;

				// Token: 0x0403F9F1 RID: 260593
				public bool OpenDebugMode;
			}

			// Token: 0x0200CE55 RID: 52821
			public class TaskBeHitMontage
			{
				// Token: 0x0403F9F2 RID: 260594
				[Nullable(1)]
				public string DefaultMontageName = "";

				// Token: 0x0403F9F3 RID: 260595
				[Nullable(new byte[]
				{
					1,
					0,
					1
				})]
				[JsonConverter(typeof(CombatStateMachineDefine.Fsm.MontageMapConverter))]
				public List<ValueTuple<int, string>> MontageMap = new List<ValueTuple<int, string>>();

				// Token: 0x0403F9F4 RID: 260596
				public float BlendInTime;
			}

			// Token: 0x0200CE56 RID: 52822
			[NullableContext(1)]
			[Nullable(new byte[]
			{
				0,
				1,
				0,
				1
			})]
			public class MontageMapConverter : JsonConverter<List<ValueTuple<int, string>>>
			{
				// Token: 0x060507EB RID: 329707 RVA: 0x01658874 File Offset: 0x01656A74
				[return: Nullable(new byte[]
				{
					1,
					0,
					1
				})]
				public override List<ValueTuple<int, string>> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
				{
					if (reader.TokenType != JsonTokenType.StartArray)
					{
						throw new JsonException("Expected start of array for tuple.");
					}
					List<ValueTuple<int, string>> list = new List<ValueTuple<int, string>>();
					while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
					{
						if (reader.TokenType != JsonTokenType.StartArray)
						{
							throw new JsonException("Expected start of array for tuple.");
						}
						reader.Read();
						int @int = reader.GetInt32();
						reader.Read();
						string @string = reader.GetString();
						reader.Read();
						list.Add(new ValueTuple<int, string>(@int, @string));
					}
					return list;
				}

				// Token: 0x060507EC RID: 329708 RVA: 0x016588F4 File Offset: 0x01656AF4
				public override void Write(Utf8JsonWriter writer, [Nullable(new byte[]
				{
					1,
					0,
					1
				})] List<ValueTuple<int, string>> value, JsonSerializerOptions options)
				{
					writer.WriteStartArray();
					foreach (ValueTuple<int, string> valueTuple in value)
					{
						writer.WriteStartArray();
						writer.WriteNumberValue(valueTuple.Item1);
						writer.WriteStringValue(valueTuple.Item2);
						writer.WriteEndArray();
					}
					writer.WriteEndArray();
				}
			}

			// Token: 0x0200CE57 RID: 52823
			public class TaskGroupPatrol
			{
			}

			// Token: 0x0200CE58 RID: 52824
			public class TaskGroupPerform
			{
			}

			// Token: 0x0200CE59 RID: 52825
			public enum EActionType
			{
				// Token: 0x0403F9F6 RID: 260598
				ActionAddBuff = 1,
				// Token: 0x0403F9F7 RID: 260599
				ActionRemoveBuff,
				// Token: 0x0403F9F8 RID: 260600
				ActionCastSkill,
				// Token: 0x0403F9F9 RID: 260601
				ActionCancelSkill,
				// Token: 0x0403F9FA RID: 260602
				ActionResetStatus = 7,
				// Token: 0x0403F9FB RID: 260603
				ActionEnterFight,
				// Token: 0x0403F9FC RID: 260604
				ActionCastSkillByName,
				// Token: 0x0403F9FD RID: 260605
				ActionCancelSkillByName,
				// Token: 0x0403F9FE RID: 260606
				ActionInstChangeStateTag,
				// Token: 0x0403F9FF RID: 260607
				ActionResetPart,
				// Token: 0x0403FA00 RID: 260608
				ActionActivatePart,
				// Token: 0x0403FA01 RID: 260609
				ActionActivateSkillGroup,
				// Token: 0x0403FA02 RID: 260610
				ActionDispatchEvent,
				// Token: 0x0403FA03 RID: 260611
				ActionSetRageFullAttribute = 19,
				// Token: 0x0403FA04 RID: 260612
				ActionAddTagCount,
				// Token: 0x0403FA05 RID: 260613
				ActionRemoveTagCount,
				// Token: 0x0403FA06 RID: 260614
				ActionDispatchGameEvent,
				// Token: 0x0403FA07 RID: 260615
				ActionCue = 101,
				// Token: 0x0403FA08 RID: 260616
				ActionStopMontage,
				// Token: 0x0403FA09 RID: 260617
				ActionExitHit,
				// Token: 0x0403FA0A RID: 260618
				ActionSendGameplayEvent,
				// Token: 0x0403FA0B RID: 260619
				ActionCameraLockOn
			}

			// Token: 0x0200CE5A RID: 52826
			[NullableContext(2)]
			[Nullable(0)]
			public class Action
			{
				// Token: 0x0403FA0C RID: 260620
				public int Type;

				// Token: 0x0403FA0D RID: 260621
				public CombatStateMachineDefine.Fsm.ActionAddBuff ActionAddBuff;

				// Token: 0x0403FA0E RID: 260622
				public CombatStateMachineDefine.Fsm.ActionRemoveBuff ActionRemoveBuff;

				// Token: 0x0403FA0F RID: 260623
				public CombatStateMachineDefine.Fsm.ActionCastSkill ActionCastSkill;

				// Token: 0x0403FA10 RID: 260624
				public CombatStateMachineDefine.Fsm.ActionCancelSkill ActionCancelSkill;

				// Token: 0x0403FA11 RID: 260625
				public CombatStateMachineDefine.Fsm.ActionResetStatus ActionResetStatus;

				// Token: 0x0403FA12 RID: 260626
				public CombatStateMachineDefine.Fsm.ActionEnterFight ActionEnterFight;

				// Token: 0x0403FA13 RID: 260627
				public CombatStateMachineDefine.Fsm.ActionCastSkillByName ActionCastSkillByName;

				// Token: 0x0403FA14 RID: 260628
				public CombatStateMachineDefine.Fsm.ActionCancelSkillByName ActionCancelSkillByName;

				// Token: 0x0403FA15 RID: 260629
				public CombatStateMachineDefine.Fsm.ActionInstChangeStateTag ActionInstChangeStateTag;

				// Token: 0x0403FA16 RID: 260630
				public CombatStateMachineDefine.Fsm.ActionResetPart ActionResetPart;

				// Token: 0x0403FA17 RID: 260631
				public CombatStateMachineDefine.Fsm.ActionActivatePart ActionActivatePart;

				// Token: 0x0403FA18 RID: 260632
				public CombatStateMachineDefine.Fsm.ActionActivateSkillGroup ActionActivateSkillGroup;

				// Token: 0x0403FA19 RID: 260633
				public CombatStateMachineDefine.Fsm.ActionDispatchEvent ActionDispatchEvent;

				// Token: 0x0403FA1A RID: 260634
				public CombatStateMachineDefine.Fsm.ActionCue ActionCue;

				// Token: 0x0403FA1B RID: 260635
				public CombatStateMachineDefine.Fsm.ActionStopMontage ActionStopMontage;

				// Token: 0x0403FA1C RID: 260636
				public CombatStateMachineDefine.Fsm.ActionExitHit ActionExitHit;

				// Token: 0x0403FA1D RID: 260637
				public CombatStateMachineDefine.Fsm.ActionSendGameplayEvent ActionSendGameplayEvent;

				// Token: 0x0403FA1E RID: 260638
				public CombatStateMachineDefine.Fsm.ActionSetRageFullAttribute ActionSetRageFullAttribute;

				// Token: 0x0403FA1F RID: 260639
				public CombatStateMachineDefine.Fsm.ActionAddTagCount ActionAddTagCount;

				// Token: 0x0403FA20 RID: 260640
				public CombatStateMachineDefine.Fsm.ActionRemoveTagCount ActionRemoveTagCount;

				// Token: 0x0403FA21 RID: 260641
				public CombatStateMachineDefine.Fsm.ActionDispatchGameEvent ActionDispatchGameEvent;

				// Token: 0x0403FA22 RID: 260642
				public CombatStateMachineDefine.Fsm.ActionCameraLockOn ActionCameraLockOn;

				// Token: 0x0403FA23 RID: 260643
				public string Name;
			}

			// Token: 0x0200CE5B RID: 52827
			public class ActionAddBuff
			{
				// Token: 0x0403FA24 RID: 260644
				public long BuffId;
			}

			// Token: 0x0200CE5C RID: 52828
			public class ActionRemoveBuff
			{
				// Token: 0x0403FA25 RID: 260645
				public long BuffId;
			}

			// Token: 0x0200CE5D RID: 52829
			public class ActionCastSkill
			{
				// Token: 0x0403FA26 RID: 260646
				public int SkillId;
			}

			// Token: 0x0200CE5E RID: 52830
			public class ActionCancelSkill
			{
				// Token: 0x0403FA27 RID: 260647
				public int SkillId;
			}

			// Token: 0x0200CE5F RID: 52831
			public class ActionResetStatus
			{
			}

			// Token: 0x0200CE60 RID: 52832
			public class ActionEnterFight
			{
			}

			// Token: 0x0200CE61 RID: 52833
			public class ActionCastSkillByName
			{
				// Token: 0x0403FA28 RID: 260648
				[Nullable(1)]
				public string SkillName = "";
			}

			// Token: 0x0200CE62 RID: 52834
			public class ActionCancelSkillByName
			{
				// Token: 0x0403FA29 RID: 260649
				[Nullable(1)]
				public string SkillName = "";
			}

			// Token: 0x0200CE63 RID: 52835
			public class ActionInstChangeStateTag
			{
				// Token: 0x0403FA2A RID: 260650
				public int TagId;
			}

			// Token: 0x0200CE64 RID: 52836
			public class ActionResetPart
			{
				// Token: 0x0403FA2B RID: 260651
				[Nullable(1)]
				public string PartName = "";

				// Token: 0x0403FA2C RID: 260652
				public bool ResetActivate;

				// Token: 0x0403FA2D RID: 260653
				public bool ResetLife;
			}

			// Token: 0x0200CE65 RID: 52837
			public class ActionActivatePart
			{
				// Token: 0x0403FA2E RID: 260654
				[Nullable(1)]
				public string PartName = "";

				// Token: 0x0403FA2F RID: 260655
				public bool Activate;
			}

			// Token: 0x0200CE66 RID: 52838
			public class ActionActivateSkillGroup
			{
				// Token: 0x0403FA30 RID: 260656
				public int ConfigId;

				// Token: 0x0403FA31 RID: 260657
				public bool Activate;
			}

			// Token: 0x0200CE67 RID: 52839
			public class ActionDispatchEvent
			{
				// Token: 0x0403FA32 RID: 260658
				[Nullable(1)]
				public string Event = "";
			}

			// Token: 0x0200CE68 RID: 52840
			public class ActionCue
			{
				// Token: 0x0403FA33 RID: 260659
				[Nullable(2)]
				public List<long> CueIds;

				// Token: 0x0403FA34 RID: 260660
				public int ConfigReplaceTagId;

				// Token: 0x0403FA35 RID: 260661
				[Nullable(1)]
				public string ConfigReplaceTagName = "";
			}

			// Token: 0x0200CE69 RID: 52841
			public class ActionStopMontage
			{
				// Token: 0x0403FA36 RID: 260662
				public float BlendOutTime;
			}

			// Token: 0x0200CE6A RID: 52842
			public class ActionExitHit
			{
			}

			// Token: 0x0200CE6B RID: 52843
			public class ActionSendGameplayEvent
			{
				// Token: 0x0403FA37 RID: 260663
				public int TagId;
			}

			// Token: 0x0200CE6C RID: 52844
			public class ActionSetRageFullAttribute
			{
			}

			// Token: 0x0200CE6D RID: 52845
			public class ActionAddTagCount
			{
				// Token: 0x0403FA38 RID: 260664
				public int TagId;

				// Token: 0x0403FA39 RID: 260665
				public int Count;
			}

			// Token: 0x0200CE6E RID: 52846
			public class ActionRemoveTagCount
			{
				// Token: 0x0403FA3A RID: 260666
				public int TagId;

				// Token: 0x0403FA3B RID: 260667
				public int Count;
			}

			// Token: 0x0200CE6F RID: 52847
			public class ActionDispatchGameEvent
			{
			}

			// Token: 0x0200CE70 RID: 52848
			public class ActionCameraLockOn
			{
				// Token: 0x0403FA3C RID: 260668
				public bool Enable;
			}

			// Token: 0x0200CE71 RID: 52849
			public enum EStateType
			{
				// Token: 0x0403FA3E RID: 260670
				BindBuff = 1,
				// Token: 0x0403FA3F RID: 260671
				BindSkill,
				// Token: 0x0403FA40 RID: 260672
				BindTag,
				// Token: 0x0403FA41 RID: 260673
				BindSkillByName,
				// Token: 0x0403FA42 RID: 260674
				BindSkillCounter = 6,
				// Token: 0x0403FA43 RID: 260675
				BindDelaySuicide,
				// Token: 0x0403FA44 RID: 260676
				BindAiHateConfig = 102,
				// Token: 0x0403FA45 RID: 260677
				BindAiSenseEnable,
				// Token: 0x0403FA46 RID: 260678
				BindCue,
				// Token: 0x0403FA47 RID: 260679
				BindDisableActor,
				// Token: 0x0403FA48 RID: 260680
				BindBoneVisible = 108,
				// Token: 0x0403FA49 RID: 260681
				BindMeshVisible,
				// Token: 0x0403FA4A RID: 260682
				BindBoneCollision,
				// Token: 0x0403FA4B RID: 260683
				BindPartPanelVisible,
				// Token: 0x0403FA4C RID: 260684
				BindDeathMontage,
				// Token: 0x0403FA4D RID: 260685
				BindPalsy,
				// Token: 0x0403FA4E RID: 260686
				BindCollisionChannel,
				// Token: 0x0403FA4F RID: 260687
				BindDisableCollision,
				// Token: 0x0403FA50 RID: 260688
				BindDeathMontageByTag
			}

			// Token: 0x0200CE72 RID: 52850
			[NullableContext(2)]
			[Nullable(0)]
			public class State
			{
				// Token: 0x0403FA51 RID: 260689
				public int Type;

				// Token: 0x0403FA52 RID: 260690
				public CombatStateMachineDefine.Fsm.BindBuff BindBuff;

				// Token: 0x0403FA53 RID: 260691
				public CombatStateMachineDefine.Fsm.BindSkill BindSkill;

				// Token: 0x0403FA54 RID: 260692
				public CombatStateMachineDefine.Fsm.BindTag BindTag;

				// Token: 0x0403FA55 RID: 260693
				public CombatStateMachineDefine.Fsm.BindSkillByName BindSkillByName;

				// Token: 0x0403FA56 RID: 260694
				public CombatStateMachineDefine.Fsm.BindSkillCounter BindSkillCounter;

				// Token: 0x0403FA57 RID: 260695
				public CombatStateMachineDefine.Fsm.BindDelaySuicide BindDelaySuicide;

				// Token: 0x0403FA58 RID: 260696
				public CombatStateMachineDefine.Fsm.BindAiHateConfig BindAiHateConfig;

				// Token: 0x0403FA59 RID: 260697
				public CombatStateMachineDefine.Fsm.BindAiSenseEnable BindAiSenseEnable;

				// Token: 0x0403FA5A RID: 260698
				public CombatStateMachineDefine.Fsm.BindCue BindCue;

				// Token: 0x0403FA5B RID: 260699
				public CombatStateMachineDefine.Fsm.BindDisableActor BindDisableActor;

				// Token: 0x0403FA5C RID: 260700
				public CombatStateMachineDefine.Fsm.BindLeaveFight BindLeaveFight;

				// Token: 0x0403FA5D RID: 260701
				public CombatStateMachineDefine.Fsm.BindMontage BindMontage;

				// Token: 0x0403FA5E RID: 260702
				public CombatStateMachineDefine.Fsm.BindBoneVisible BindBoneVisible;

				// Token: 0x0403FA5F RID: 260703
				public CombatStateMachineDefine.Fsm.BindMeshVisible BindMeshVisible;

				// Token: 0x0403FA60 RID: 260704
				public CombatStateMachineDefine.Fsm.BindBoneCollision BindBoneCollision;

				// Token: 0x0403FA61 RID: 260705
				public CombatStateMachineDefine.Fsm.BindPartPanelVisible BindPartPanelVisible;

				// Token: 0x0403FA62 RID: 260706
				public CombatStateMachineDefine.Fsm.BindDeathMontage BindDeathMontage;

				// Token: 0x0403FA63 RID: 260707
				public CombatStateMachineDefine.Fsm.BindPalsy BindPalsy;

				// Token: 0x0403FA64 RID: 260708
				public CombatStateMachineDefine.Fsm.BindCollisionChannel BindCollisionChannel;

				// Token: 0x0403FA65 RID: 260709
				public CombatStateMachineDefine.Fsm.BindDisableCollision BindDisableCollision;

				// Token: 0x0403FA66 RID: 260710
				public CombatStateMachineDefine.Fsm.BindDeathMontageByTag BindDeathMontageByTag;

				// Token: 0x0403FA67 RID: 260711
				public string Name;
			}

			// Token: 0x0200CE73 RID: 52851
			public class BindBuff
			{
				// Token: 0x0403FA68 RID: 260712
				public long BuffId;
			}

			// Token: 0x0200CE74 RID: 52852
			public class BindSkill
			{
				// Token: 0x0403FA69 RID: 260713
				public int SkillId;
			}

			// Token: 0x0200CE75 RID: 52853
			public class BindTag
			{
				// Token: 0x0403FA6A RID: 260714
				public int TagId;
			}

			// Token: 0x0200CE76 RID: 52854
			public class BindSkillByName
			{
				// Token: 0x0403FA6B RID: 260715
				[Nullable(1)]
				public string SkillName = "";
			}

			// Token: 0x0200CE77 RID: 52855
			public class BindSkillCounter
			{
				// Token: 0x0403FA6C RID: 260716
				[Nullable(2)]
				public int[] SkillIds;

				// Token: 0x0403FA6D RID: 260717
				[Nullable(1)]
				public string BlackboardKey = "";

				// Token: 0x0403FA6E RID: 260718
				public int AddValueMin;

				// Token: 0x0403FA6F RID: 260719
				public int AddValueMax;

				// Token: 0x0403FA70 RID: 260720
				public bool Reset;
			}

			// Token: 0x0200CE78 RID: 52856
			public class BindDelaySuicide
			{
				// Token: 0x0403FA71 RID: 260721
				public float SuicideDelay;

				// Token: 0x0403FA72 RID: 260722
				public float DestroyDelay;
			}

			// Token: 0x0200CE79 RID: 52857
			public class BindActivateSkillGroup
			{
				// Token: 0x0403FA73 RID: 260723
				public int ConfigId;
			}

			// Token: 0x0200CE7A RID: 52858
			public class BindAiHateConfig
			{
				// Token: 0x0403FA74 RID: 260724
				public int ConfigId;
			}

			// Token: 0x0200CE7B RID: 52859
			public class BindAiSenseEnable
			{
				// Token: 0x0403FA75 RID: 260725
				public int ConfigId;
			}

			// Token: 0x0200CE7C RID: 52860
			public class BindCue
			{
				// Token: 0x0403FA76 RID: 260726
				[Nullable(2)]
				public List<long> CueIds;

				// Token: 0x0403FA77 RID: 260727
				public bool HideOnLoading;

				// Token: 0x0403FA78 RID: 260728
				public int ConfigReplaceTagId;

				// Token: 0x0403FA79 RID: 260729
				[Nullable(1)]
				public string ConfigReplaceTagName = "";
			}

			// Token: 0x0200CE7D RID: 52861
			public class BindDisableActor
			{
			}

			// Token: 0x0200CE7E RID: 52862
			public class BindLeaveFight
			{
				// Token: 0x0403FA7A RID: 260730
				public float RandomRadius;

				// Token: 0x0403FA7B RID: 260731
				public float MinWanderDistance;

				// Token: 0x0403FA7C RID: 260732
				public float MaxNavigationMillisecond;

				// Token: 0x0403FA7D RID: 260733
				public bool MoveStateForWanderOrReset;

				// Token: 0x0403FA7E RID: 260734
				public float MaxStopTime;

				// Token: 0x0403FA7F RID: 260735
				public float BlinkTime;

				// Token: 0x0403FA80 RID: 260736
				public bool UsePatrolPointPriority;
			}

			// Token: 0x0200CE7F RID: 52863
			public class BindMontage
			{
				// Token: 0x0403FA81 RID: 260737
				[Nullable(1)]
				public string MontageName = "";

				// Token: 0x0403FA82 RID: 260738
				public bool HideOnLoading;
			}

			// Token: 0x0200CE80 RID: 52864
			public class BindBoneVisible
			{
				// Token: 0x0403FA83 RID: 260739
				[Nullable(1)]
				public string BoneName = "";

				// Token: 0x0403FA84 RID: 260740
				public bool Visible;
			}

			// Token: 0x0200CE81 RID: 52865
			public class BindMeshVisible
			{
				// Token: 0x0403FA85 RID: 260741
				[Nullable(1)]
				public string Tag = "";

				// Token: 0x0403FA86 RID: 260742
				public bool Visible;

				// Token: 0x0403FA87 RID: 260743
				public bool PropagateToChildren;
			}

			// Token: 0x0200CE82 RID: 52866
			public class BindBoneCollision
			{
				// Token: 0x0403FA88 RID: 260744
				[Nullable(1)]
				public string BoneName = "";

				// Token: 0x0403FA89 RID: 260745
				public bool IsBlockPawn;

				// Token: 0x0403FA8A RID: 260746
				public bool IsBulletDetect;

				// Token: 0x0403FA8B RID: 260747
				public bool IsBlockCamera;

				// Token: 0x0403FA8C RID: 260748
				public bool IsBlockPawnOnExit;

				// Token: 0x0403FA8D RID: 260749
				public bool IsBulletDetectOnExit;

				// Token: 0x0403FA8E RID: 260750
				public bool IsBlockCameraOnExit;

				// Token: 0x0403FA8F RID: 260751
				public bool IsActiveOcclusionDither;

				// Token: 0x0403FA90 RID: 260752
				public bool IsActiveOcclusionDitherOnExit;
			}

			// Token: 0x0200CE83 RID: 52867
			public class BindPartPanelVisible
			{
				// Token: 0x0403FA91 RID: 260753
				[Nullable(1)]
				public string PartName = "";

				// Token: 0x0403FA92 RID: 260754
				public bool Visible;
			}

			// Token: 0x0200CE84 RID: 52868
			public class BindDeathMontage
			{
				// Token: 0x0403FA93 RID: 260755
				public int DeathType;

				// Token: 0x0403FA94 RID: 260756
				[Nullable(1)]
				public string MontageName = "";
			}

			// Token: 0x0200CE85 RID: 52869
			public class BindDeathMontageByTag
			{
				// Token: 0x0403FA95 RID: 260757
				[Nullable(2)]
				public int[] MontageTagIds;

				// Token: 0x0403FA96 RID: 260758
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public string[] MontageTagNames;

				// Token: 0x0403FA97 RID: 260759
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public string[] TagMontageNames;
			}

			// Token: 0x0200CE86 RID: 52870
			[NullableContext(1)]
			[Nullable(0)]
			public class BindPalsy
			{
				// Token: 0x0403FA98 RID: 260760
				public string CounterAttackEffect = "";

				// Token: 0x0403FA99 RID: 260761
				public string CounterAttackCamera = "";
			}

			// Token: 0x0200CE87 RID: 52871
			public class BindCollisionChannel
			{
				// Token: 0x0403FA9A RID: 260762
				[Nullable(2)]
				public List<int> IgnoreChannels;
			}

			// Token: 0x0200CE88 RID: 52872
			public class BindDisableCollision
			{
			}

			// Token: 0x0200CE89 RID: 52873
			public enum EConditionType
			{
				// Token: 0x0403FA9C RID: 260764
				CondAnd = 1,
				// Token: 0x0403FA9D RID: 260765
				CondOr,
				// Token: 0x0403FA9E RID: 260766
				CondTrue = 4,
				// Token: 0x0403FA9F RID: 260767
				CondHpLessThan = 11,
				// Token: 0x0403FAA0 RID: 260768
				CondSkillEnd = 13,
				// Token: 0x0403FAA1 RID: 260769
				CondTag,
				// Token: 0x0403FAA2 RID: 260770
				CondBBValueCompare,
				// Token: 0x0403FAA3 RID: 260771
				CondAttrCompare,
				// Token: 0x0403FAA4 RID: 260772
				CondAttribute,
				// Token: 0x0403FAA5 RID: 260773
				CondAttributeRate,
				// Token: 0x0403FAA6 RID: 260774
				CondCheckState,
				// Token: 0x0403FAA7 RID: 260775
				CondHate,
				// Token: 0x0403FAA8 RID: 260776
				CondTimer = 22,
				// Token: 0x0403FAA9 RID: 260777
				CondWaitClient,
				// Token: 0x0403FAAA RID: 260778
				CondCheckStateByName,
				// Token: 0x0403FAAB RID: 260779
				CondInstStateChange,
				// Token: 0x0403FAAC RID: 260780
				CondBuffStack,
				// Token: 0x0403FAAD RID: 260781
				CondPartLife,
				// Token: 0x0403FAAE RID: 260782
				CondCheckPartActivated,
				// Token: 0x0403FAAF RID: 260783
				CondListenEvent,
				// Token: 0x0403FAB0 RID: 260784
				CondCheckLastState = 31,
				// Token: 0x0403FAB1 RID: 260785
				CondCheckDissolveCombine,
				// Token: 0x0403FAB2 RID: 260786
				CondTaskFinish = 101,
				// Token: 0x0403FAB3 RID: 260787
				CondMontageTimeRemaining,
				// Token: 0x0403FAB4 RID: 260788
				CondListenBeHit,
				// Token: 0x0403FAB5 RID: 260789
				CondHasMoveInput,
				// Token: 0x0403FAB6 RID: 260790
				CondMontageTimeElapsing,
				// Token: 0x0403FAB7 RID: 260791
				CondCheckGroupPatrol,
				// Token: 0x0403FAB8 RID: 260792
				CondCheckPositionState = 108,
				// Token: 0x0403FAB9 RID: 260793
				CondCheckGroupPerform
			}

			// Token: 0x0200CE8A RID: 52874
			[NullableContext(2)]
			[Nullable(0)]
			public class Condition
			{
				// Token: 0x0403FABA RID: 260794
				public int Type;

				// Token: 0x0403FABB RID: 260795
				public bool Reverse;

				// Token: 0x0403FABC RID: 260796
				public int Index;

				// Token: 0x0403FABD RID: 260797
				public bool? IsClient;

				// Token: 0x0403FABE RID: 260798
				public CombatStateMachineDefine.Fsm.CondAnd CondAnd;

				// Token: 0x0403FABF RID: 260799
				public CombatStateMachineDefine.Fsm.CondOr CondOr;

				// Token: 0x0403FAC0 RID: 260800
				public CombatStateMachineDefine.Fsm.CondTrue CondTrue;

				// Token: 0x0403FAC1 RID: 260801
				public CombatStateMachineDefine.Fsm.CondHpLessThan CondHpLessThan;

				// Token: 0x0403FAC2 RID: 260802
				public CombatStateMachineDefine.Fsm.CondSkillEnd CondSkillEnd;

				// Token: 0x0403FAC3 RID: 260803
				public CombatStateMachineDefine.Fsm.CondTag CondTag;

				// Token: 0x0403FAC4 RID: 260804
				public CombatStateMachineDefine.Fsm.CondBBValueCompare CondBBValueCompare;

				// Token: 0x0403FAC5 RID: 260805
				public CombatStateMachineDefine.Fsm.CondAttrCompare CondAttrCompare;

				// Token: 0x0403FAC6 RID: 260806
				public CombatStateMachineDefine.Fsm.CondAttribute CondAttribute;

				// Token: 0x0403FAC7 RID: 260807
				public CombatStateMachineDefine.Fsm.CondAttributeRate CondAttributeRate;

				// Token: 0x0403FAC8 RID: 260808
				public CombatStateMachineDefine.Fsm.CondCheckState CondCheckState;

				// Token: 0x0403FAC9 RID: 260809
				public CombatStateMachineDefine.Fsm.CondHate CondHate;

				// Token: 0x0403FACA RID: 260810
				public CombatStateMachineDefine.Fsm.CondTimer CondTimer;

				// Token: 0x0403FACB RID: 260811
				public CombatStateMachineDefine.Fsm.CondWaitClient CondWaitClient;

				// Token: 0x0403FACC RID: 260812
				public CombatStateMachineDefine.Fsm.CondCheckStateByName CondCheckStateByName;

				// Token: 0x0403FACD RID: 260813
				public CombatStateMachineDefine.Fsm.CondInstStateChange CondInstStateChange;

				// Token: 0x0403FACE RID: 260814
				public CombatStateMachineDefine.Fsm.CondBuffStack CondBuffStack;

				// Token: 0x0403FACF RID: 260815
				public CombatStateMachineDefine.Fsm.CondPartLife CondPartLife;

				// Token: 0x0403FAD0 RID: 260816
				public CombatStateMachineDefine.Fsm.CondCheckPartActivated CondCheckPartActivated;

				// Token: 0x0403FAD1 RID: 260817
				public CombatStateMachineDefine.Fsm.CondListenEvent CondListenEvent;

				// Token: 0x0403FAD2 RID: 260818
				public CombatStateMachineDefine.Fsm.CondCheckPositionState CondCheckPositionState;

				// Token: 0x0403FAD3 RID: 260819
				public CombatStateMachineDefine.Fsm.CondTaskFinish CondTaskFinish;

				// Token: 0x0403FAD4 RID: 260820
				public CombatStateMachineDefine.Fsm.CondMontageTimeRemaining CondMontageTimeRemaining;

				// Token: 0x0403FAD5 RID: 260821
				public CombatStateMachineDefine.Fsm.CondListenBeHit CondListenBeHit;

				// Token: 0x0403FAD6 RID: 260822
				public CombatStateMachineDefine.Fsm.CondHasMoveInput CondHasMoveInput;

				// Token: 0x0403FAD7 RID: 260823
				public CombatStateMachineDefine.Fsm.CondMontageTimeElapsing CondMontageTimeElapsing;

				// Token: 0x0403FAD8 RID: 260824
				public CombatStateMachineDefine.Fsm.CondCheckGroupPatrol CondCheckGroupPatrol;

				// Token: 0x0403FAD9 RID: 260825
				public CombatStateMachineDefine.Fsm.CondCheckGroupPerform CondCheckGroupPerform;

				// Token: 0x0403FADA RID: 260826
				public CombatStateMachineDefine.Fsm.CondCheckLastState CondCheckLastState;

				// Token: 0x0403FADB RID: 260827
				public CombatStateMachineDefine.Fsm.CondCheckDissolveCombine CondCheckDissolveCombine;

				// Token: 0x0403FADC RID: 260828
				public string Name;
			}

			// Token: 0x0200CE8B RID: 52875
			public class CondAnd
			{
				// Token: 0x0403FADD RID: 260829
				[Nullable(2)]
				public List<int> Conditions;
			}

			// Token: 0x0200CE8C RID: 52876
			public class CondOr
			{
				// Token: 0x0403FADE RID: 260830
				[Nullable(2)]
				public List<int> Conditions;
			}

			// Token: 0x0200CE8D RID: 52877
			public class CondTrue
			{
			}

			// Token: 0x0200CE8E RID: 52878
			public class CondHpLessThan
			{
				// Token: 0x0403FADF RID: 260831
				public float HpRatio;
			}

			// Token: 0x0200CE8F RID: 52879
			public class CondSkillEnd
			{
			}

			// Token: 0x0200CE90 RID: 52880
			public class CondTag
			{
				// Token: 0x0403FAE0 RID: 260832
				public int TagId;

				// Token: 0x0403FAE1 RID: 260833
				[Nullable(1)]
				public string TagName = "";
			}

			// Token: 0x0200CE91 RID: 52881
			public class CondBBValueCompare
			{
				// Token: 0x0403FAE2 RID: 260834
				public int Key1;

				// Token: 0x0403FAE3 RID: 260835
				public int Key2;

				// Token: 0x0403FAE4 RID: 260836
				public int Compare;
			}

			// Token: 0x0200CE92 RID: 52882
			public class CondAttrCompare
			{
				// Token: 0x0403FAE5 RID: 260837
				public int Attr1;

				// Token: 0x0403FAE6 RID: 260838
				public int Attr2;

				// Token: 0x0403FAE7 RID: 260839
				public int Compare;
			}

			// Token: 0x0200CE93 RID: 52883
			public class CondAttribute
			{
				// Token: 0x0403FAE8 RID: 260840
				public int AttributeId;

				// Token: 0x0403FAE9 RID: 260841
				public float Min;

				// Token: 0x0403FAEA RID: 260842
				public float Max;
			}

			// Token: 0x0200CE94 RID: 52884
			public class CondAttributeRate
			{
				// Token: 0x0403FAEB RID: 260843
				public int AttributeId;

				// Token: 0x0403FAEC RID: 260844
				public float Denominator;

				// Token: 0x0403FAED RID: 260845
				public float Min;

				// Token: 0x0403FAEE RID: 260846
				public float Max;
			}

			// Token: 0x0200CE95 RID: 52885
			public class CondCheckState
			{
				// Token: 0x0403FAEF RID: 260847
				public int TargetState;
			}

			// Token: 0x0200CE96 RID: 52886
			public class CondHate
			{
			}

			// Token: 0x0200CE97 RID: 52887
			public class CondTimer
			{
				// Token: 0x0403FAF0 RID: 260848
				public float MinTime;

				// Token: 0x0403FAF1 RID: 260849
				public float MaxTime;
			}

			// Token: 0x0200CE98 RID: 52888
			public class CondWaitClient
			{
			}

			// Token: 0x0200CE99 RID: 52889
			public class CondCheckStateByName
			{
				// Token: 0x0403FAF2 RID: 260850
				[Nullable(1)]
				public string TargetStateName = "";
			}

			// Token: 0x0200CE9A RID: 52890
			public class CondInstStateChange
			{
				// Token: 0x0403FAF3 RID: 260851
				public int TagId;
			}

			// Token: 0x0200CE9B RID: 52891
			public class CondBuffStack
			{
				// Token: 0x0403FAF4 RID: 260852
				public long BuffId;

				// Token: 0x0403FAF5 RID: 260853
				public int MinStack;

				// Token: 0x0403FAF6 RID: 260854
				public int MaxStack;
			}

			// Token: 0x0200CE9C RID: 52892
			public class CondPartLife
			{
				// Token: 0x0403FAF7 RID: 260855
				[Nullable(1)]
				public string PartName = "";

				// Token: 0x0403FAF8 RID: 260856
				public bool CheckRate;

				// Token: 0x0403FAF9 RID: 260857
				public float Min;

				// Token: 0x0403FAFA RID: 260858
				public float Max;
			}

			// Token: 0x0200CE9D RID: 52893
			public class CondCheckPartActivated
			{
				// Token: 0x0403FAFB RID: 260859
				[Nullable(1)]
				public string PartName = "";
			}

			// Token: 0x0200CE9E RID: 52894
			public class CondListenEvent
			{
				// Token: 0x0403FAFC RID: 260860
				[Nullable(1)]
				public string Event = "";
			}

			// Token: 0x0200CE9F RID: 52895
			public class CondCheckPositionState
			{
				// Token: 0x0403FAFD RID: 260861
				public int PositionState;
			}

			// Token: 0x0200CEA0 RID: 52896
			public class CondTaskFinish
			{
			}

			// Token: 0x0200CEA1 RID: 52897
			public class CondMontageTimeRemaining
			{
				// Token: 0x0403FAFE RID: 260862
				public float Time;
			}

			// Token: 0x0200CEA2 RID: 52898
			public class CondListenBeHit
			{
				// Token: 0x0403FAFF RID: 260863
				public bool NoHitAnimation;

				// Token: 0x0403FB00 RID: 260864
				public bool SoftKnock;

				// Token: 0x0403FB01 RID: 260865
				public bool HeavyKnock;

				// Token: 0x0403FB02 RID: 260866
				public bool KnockUp;

				// Token: 0x0403FB03 RID: 260867
				public bool KnockDown;

				// Token: 0x0403FB04 RID: 260868
				public bool Parry;

				// Token: 0x0403FB05 RID: 260869
				public bool BreakWeakness;

				// Token: 0x0403FB06 RID: 260870
				public int VisionCounterAttackId;
			}

			// Token: 0x0200CEA3 RID: 52899
			public class CondHasMoveInput
			{
			}

			// Token: 0x0200CEA4 RID: 52900
			public class CondCheckGroupPatrol
			{
			}

			// Token: 0x0200CEA5 RID: 52901
			public class CondCheckGroupPerform
			{
			}

			// Token: 0x0200CEA6 RID: 52902
			public class CondMontageTimeElapsing
			{
				// Token: 0x0403FB07 RID: 260871
				public float Time;
			}

			// Token: 0x0200CEA7 RID: 52903
			public class CondCheckLastState
			{
				// Token: 0x0403FB08 RID: 260872
				[Nullable(1)]
				public string TargetStateName = "";
			}

			// Token: 0x0200CEA8 RID: 52904
			public class CondCheckDissolveCombine
			{
			}

			// Token: 0x0200CEA9 RID: 52905
			public enum ETransitionPredictionType
			{
				// Token: 0x0403FB0A RID: 260874
				Server,
				// Token: 0x0403FB0B RID: 260875
				Autonomous,
				// Token: 0x0403FB0C RID: 260876
				Simulated
			}

			// Token: 0x0200CEAA RID: 52906
			public class Transition
			{
				// Token: 0x0403FB0D RID: 260877
				public int From;

				// Token: 0x0403FB0E RID: 260878
				public int To;

				// Token: 0x0403FB0F RID: 260879
				public CombatStateMachineDefine.Fsm.ETransitionPredictionType? TransitionPredictionType;

				// Token: 0x0403FB10 RID: 260880
				public int Weight;

				// Token: 0x0403FB11 RID: 260881
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.Condition> Conditions;
			}

			// Token: 0x0200CEAB RID: 52907
			public enum ETakeControlType
			{
				// Token: 0x0403FB13 RID: 260883
				Default,
				// Token: 0x0403FB14 RID: 260884
				ReEnter
			}

			// Token: 0x0200CEAC RID: 52908
			public enum ETransitionRule
			{
				// Token: 0x0403FB16 RID: 260886
				Priority,
				// Token: 0x0403FB17 RID: 260887
				Weight
			}

			// Token: 0x0200CEAD RID: 52909
			[NullableContext(2)]
			[Nullable(0)]
			public class Node
			{
				// Token: 0x0403FB18 RID: 260888
				public int Uuid;

				// Token: 0x0403FB19 RID: 260889
				public int? ReferenceUuid;

				// Token: 0x0403FB1A RID: 260890
				public int? OverrideCommonUuid;

				// Token: 0x0403FB1B RID: 260891
				public bool IsAnimStateMachine;

				// Token: 0x0403FB1C RID: 260892
				public bool IsConduitNode;

				// Token: 0x0403FB1D RID: 260893
				public bool IsAnyState;

				// Token: 0x0403FB1E RID: 260894
				[Nullable(1)]
				public string Name = "";

				// Token: 0x0403FB1F RID: 260895
				public CombatStateMachineDefine.Fsm.ETakeControlType TakeControlType;

				// Token: 0x0403FB20 RID: 260896
				public CombatStateMachineDefine.Fsm.ETransitionRule TransitionRule;

				// Token: 0x0403FB21 RID: 260897
				public CombatStateMachineDefine.Fsm.Task Task;

				// Token: 0x0403FB22 RID: 260898
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.State> BindStates;

				// Token: 0x0403FB23 RID: 260899
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.Action> OnEnterActions;

				// Token: 0x0403FB24 RID: 260900
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.Action> OnExitActions;

				// Token: 0x0403FB25 RID: 260901
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.Transition> Transitions;

				// Token: 0x0403FB26 RID: 260902
				public List<int> Children;
			}

			// Token: 0x0200CEAE RID: 52910
			public class StateMachineGroup
			{
				// Token: 0x0403FB27 RID: 260903
				public int? Version;

				// Token: 0x0403FB28 RID: 260904
				[Nullable(2)]
				public List<int> StateMachines;

				// Token: 0x0403FB29 RID: 260905
				[Nullable(new byte[]
				{
					2,
					1
				})]
				public List<CombatStateMachineDefine.Fsm.Node> Nodes;
			}
		}
	}
}
