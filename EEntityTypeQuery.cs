using System;

// Token: 0x0200009B RID: 155
[Flags]
public enum EEntityTypeQuery
{
	// Token: 0x040003B8 RID: 952
	NormalEntity = 1,
	// Token: 0x040003B9 RID: 953
	NormalEntityAlwaysTick = 2,
	// Token: 0x040003BA RID: 954
	NormalEntityAlwaysTickWhitoutNotRenderedGroup = 4,
	// Token: 0x040003BB RID: 955
	MoveSceneItem = 8,
	// Token: 0x040003BC RID: 956
	SimpleNPC = 16,
	// Token: 0x040003BD RID: 957
	NormalNPC = 32,
	// Token: 0x040003BE RID: 958
	PasserbyNPC = 64,
	// Token: 0x040003BF RID: 959
	Monster = 64,
	// Token: 0x040003C0 RID: 960
	Animal = 64,
	// Token: 0x040003C1 RID: 961
	Boss = 128,
	// Token: 0x040003C2 RID: 962
	Team = 256,
	// Token: 0x040003C3 RID: 963
	MasterRole = 256,
	// Token: 0x040003C4 RID: 964
	MasterRoleDerivedMonster = 256,
	// Token: 0x040003C5 RID: 965
	Vision = 256,
	// Token: 0x040003C6 RID: 966
	SceneItem = 15,
	// Token: 0x040003C7 RID: 967
	Player = 256,
	// Token: 0x040003C8 RID: 968
	Character = 496,
	// Token: 0x040003C9 RID: 969
	SceneItemOrCharacter = 511,
	// Token: 0x040003CA RID: 970
	All = 511,
	// Token: 0x040003CB RID: 971
	Custom = 512,
	// Token: 0x040003CC RID: 972
	MaxIndex = 9
}
