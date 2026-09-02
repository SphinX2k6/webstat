using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x02005385 RID: 21381
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceDefine
	{
		// Token: 0x0401F654 RID: 128596
		public const float FRAME_PER_MILLISECOND = 0.03f;

		// Token: 0x0401F655 RID: 128597
		[StaticVariableRuleIgnore]
		public static FName MALE_TAG = new FName("Male");

		// Token: 0x0401F656 RID: 128598
		[StaticVariableRuleIgnore]
		public static FName FEMALE_TAG = new FName("Female");

		// Token: 0x0401F657 RID: 128599
		[StaticVariableRuleIgnore]
		public static FName HERO_TAG = new FName("Player");

		// Token: 0x0401F658 RID: 128600
		[StaticVariableRuleIgnore]
		public static FName BOSS_TAG = new FName("BOSS");

		// Token: 0x0401F659 RID: 128601
		[StaticVariableRuleIgnore]
		public static FName CAMERA_TAG = new FName("SequenceCamera");

		// Token: 0x0401F65A RID: 128602
		[StaticVariableRuleIgnore]
		public static FName TALK_NPC_TAG = new FName("TalkNPC");

		// Token: 0x0401F65B RID: 128603
		[StaticVariableRuleIgnore]
		public static FName FREEATTACH_TAG = new FName("FreeAttach");

		// Token: 0x0401F65C RID: 128604
		[StaticVariableRuleIgnore]
		public static FName ABP_Base_Name = new FName("ABP_Base");

		// Token: 0x0401F65D RID: 128605
		[StaticVariableRuleIgnore]
		public static FName ABP_Seq_Slot_Name = new FName("KuroSequenceSlot");

		// Token: 0x0401F65E RID: 128606
		[StaticVariableRuleIgnore]
		public static FName ABP_Mouth_Slot_Name = new FName("SeqMouth");

		// Token: 0x0401F65F RID: 128607
		[StaticVariableRuleIgnore]
		public static FName SeqStreamingSourceProxy_TAG = new FName("StreamingSource");

		// Token: 0x0401F660 RID: 128608
		[StaticVariableRuleIgnore]
		public static FName FINAL_POS_TAG = new FName("FinalPos");

		// Token: 0x0401F661 RID: 128609
		[StaticVariableRuleIgnore]
		public static FName MOTOR_TAG = new FName("Motor");

		// Token: 0x0401F662 RID: 128610
		[StaticVariableRuleIgnore]
		public static FName DEFAULT_SEQ_SLOT = new FName("KuroSequenceSlot");

		// Token: 0x0401F663 RID: 128611
		public const int MALE_SEQ_MODEL_ID = 110004;

		// Token: 0x0401F664 RID: 128612
		public const int FEMALE_SEQ_MODEL_ID = 110006;

		// Token: 0x0401F665 RID: 128613
		public const int PLOT_WAIT_ENTITY_TIME = -1;

		// Token: 0x0401F666 RID: 128614
		public const int DEFAULT_LAST_SUBTITLE_TIME = 1;

		// Token: 0x0401F667 RID: 128615
		public const int MAX_FRAME = 9999999;

		// Token: 0x0401F668 RID: 128616
		public const string MALE_DEFAULT = "/Game/Aki/Character/Role/MaleM/Nanzhu/Seq/BP_Nanzhu_Seq_V2.BP_Nanzhu_Seq_V2_C";

		// Token: 0x0401F669 RID: 128617
		public const string FEMALE_DEFAULT = "/Game/Aki/Character/Role/FemaleM/Nvzhu/Seq/BP_Nvzhu_Seq_V2.BP_Nvzhu_Seq_V2_C";
	}
}
