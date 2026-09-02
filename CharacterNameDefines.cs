using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E3D RID: 11837
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterNameDefines : Singleton<CharacterNameDefines>
{
	// Token: 0x0400BA55 RID: 47701
	public FName NORMAL = new FName("Normal");

	// Token: 0x0400BA56 RID: 47702
	public FName ABP_BASE = new FName("ABP_Base");

	// Token: 0x0400BA57 RID: 47703
	public FName ABP_GAMEPLAY = new FName("ABP_Gameplay");

	// Token: 0x0400BA58 RID: 47704
	public FName ABP_SPECIAL = new FName("ABP_Special");

	// Token: 0x0400BA59 RID: 47705
	public FName ROOT_ROTATABLE = new FName("RootRotatable");

	// Token: 0x0400BA5A RID: 47706
	public FName ROOT_X = new FName("RootX");

	// Token: 0x0400BA5B RID: 47707
	public FName ROOT_Y = new FName("RootY");

	// Token: 0x0400BA5C RID: 47708
	public FName ROOT_Z = new FName("RootZ");

	// Token: 0x0400BA5D RID: 47709
	public FName ROOT_LOOK = new FName("RootLook");

	// Token: 0x0400BA5E RID: 47710
	public FName SEAT_MORPH = new FName("SeatMorph");

	// Token: 0x0400BA5F RID: 47711
	public FName BIP_001_SPINE = new FName("Bip001Spine");

	// Token: 0x0400BA60 RID: 47712
	public FName BIP_001_HEAD = new FName("Bip001Head");

	// Token: 0x0400BA61 RID: 47713
	public FName BIP_001_NECK = new FName("Bip001Neck");

	// Token: 0x0400BA62 RID: 47714
	public FName NO_SLIDE = new FName("NoSlide");

	// Token: 0x0400BA63 RID: 47715
	public FName NO_VAULT = new FName("NoVault");

	// Token: 0x0400BA64 RID: 47716
	public FName INVALID_POS = new FName("InvalidPos");

	// Token: 0x0400BA65 RID: 47717
	public FName ROOT = new FName("Root");

	// Token: 0x0400BA66 RID: 47718
	public FName PAWN = new FName("Pawn");

	// Token: 0x0400BA67 RID: 47719
	public FName VANISH_PAWN = new FName("VanishPawn");

	// Token: 0x0400BA68 RID: 47720
	public FName ENABLE_MOVE_TRIGGER_TAG = new FName("EnableMoveTrigger");

	// Token: 0x0400BA69 RID: 47721
	public FName HULU_SOCKET_NAME = new FName("HuluProp01");

	// Token: 0x0400BA6A RID: 47722
	public FName HULU_GLIDEING_SOCKET_NAME = new FName("Bone_Piao012");

	// Token: 0x0400BA6B RID: 47723
	public FName HULU_HAND_SOCKET_NAME = new FName("WeaponProp07");

	// Token: 0x0400BA6C RID: 47724
	public FName HULU_EFFECT_SOCKET_NAME = new FName("WeaponProp02");

	// Token: 0x0400BA6D RID: 47725
	public FName ELEMENT_EFFECT_SOCKET_NAME = new FName("Bip001RHand");

	// Token: 0x0400BA6E RID: 47726
	public FName GLIDEING_SOCKETNAME = new FName("WeaponProp01");

	// Token: 0x0400BA6F RID: 47727
	public FName CHAR_MESH_COMP_NAME = new FName("CharacterMesh0");

	// Token: 0x0400BA70 RID: 47728
	public FName POINT_CLOUD_WORLD_COMP_NAME = new FName("KuroPointCloudWorldComponent");

	// Token: 0x0400BA71 RID: 47729
	public FName WEAPON_MESH_COMP_NAME_0 = new FName("WeaponCase0");

	// Token: 0x0400BA72 RID: 47730
	public FName WEAPON_MESH_COMP_NAME_1 = new FName("WeaponCase1");

	// Token: 0x0400BA73 RID: 47731
	public FName WEAPON_MESH_COMP_NAME_2 = new FName("WeaponCase2");

	// Token: 0x0400BA74 RID: 47732
	public FName HULU_MESH_COMP_NAME = new FName("HuluCase");

	// Token: 0x0400BA75 RID: 47733
	public FName PARAGLIDING_MESH_COMP_NAME = new FName("OtherCase0");

	// Token: 0x0400BA76 RID: 47734
	public FName SOAR_WING_MESH_COMP_NAME = new FName("GenericCase0");

	// Token: 0x0400BA77 RID: 47735
	public FName KEEP_WEAPON_OUT_NAME = new FName("KeepWeaponOut");

	// Token: 0x0400BA78 RID: 47736
	public FName PFT_NO_SPAWN = new FName("PFT_NoSpawn");

	// Token: 0x0400BA79 RID: 47737
	public FName START_SECTION = new FName("Start");

	// Token: 0x0400BA7A RID: 47738
	public FName END_SECTION = new FName("End");

	// Token: 0x0400BA7B RID: 47739
	public FName LOOP_SECTION = new FName("Loop");

	// Token: 0x0400BA7C RID: 47740
	public FName NULL_SECTION = new FName("Null");

	// Token: 0x0400BA7D RID: 47741
	public FName DEFAULT_SLOT = new FName("DefaultSlot");

	// Token: 0x0400BA7E RID: 47742
	public FName SEQUENCE_SLOT = new FName("KuroSequenceSlot");

	// Token: 0x0400BA7F RID: 47743
	public FName FACE_SLOT = new FName("SeqFace");

	// Token: 0x0400BA80 RID: 47744
	public FName DEFAULT_SECTION_NAME = new FName("Default");

	// Token: 0x0400BA81 RID: 47745
	public FName ROLE_TRIGGER_NAME = new FName("RoleTrigger");

	// Token: 0x0400BA82 RID: 47746
	public FName HULU_CASE = new FName("HuluCase");

	// Token: 0x0400BA83 RID: 47747
	public FName HULU_PROP_01 = new FName("HuluProp01");

	// Token: 0x0400BA84 RID: 47748
	public FName HIT_CASE_NAME = new FName("HitCase");

	// Token: 0x0400BA85 RID: 47749
	public FName ANIM_INSTANCE_ROLE = new FName("KuroAnimInstanceRole");

	// Token: 0x0400BA86 RID: 47750
	public FName ABP_BASEROLE = new FName("ABP_BaseRole_C");

	// Token: 0x0400BA87 RID: 47751
	public FName ABP_BASEROLENPC = new FName("ABP_BaseRoleNpc_C");

	// Token: 0x0400BA88 RID: 47752
	public FName ABP_MONSTERCOMMON = new FName("ABP_MonsterCommon_C");

	// Token: 0x0400BA89 RID: 47753
	public FName ABP_BASEANIMAL = new FName("ABP_BaseAnimal_C");

	// Token: 0x0400BA8A RID: 47754
	public FName ABP_BASERUNANIMAL = new FName("ABP_BaseRunAnimal_C");

	// Token: 0x0400BA8B RID: 47755
	public FName BP_COMMONPET = new FName("BP_CommonPet_C");

	// Token: 0x0400BA8C RID: 47756
	public FName BP_BASEANIMAL = new FName("BP_BaseAnimal_C");

	// Token: 0x0400BA8D RID: 47757
	public FName BP_BASEITEM = new FName("BP_BaseItem_C");

	// Token: 0x0400BA8E RID: 47758
	public FName BP_BASEVISION = new FName("BP_BaseVision_C");

	// Token: 0x0400BA8F RID: 47759
	public FName CHANGE_SKELETAL_MATERIALS_COMP_NAME = new FName("KuroChangeSkeletalMaterialsComponent");
}
