using System;
using UnrealEngine;

// Token: 0x02000085 RID: 133
public static class KuroCollisionChannel
{
	// Token: 0x04000314 RID: 788
	public static readonly ECollisionChannel WorldStatic = ECollisionChannel.ECC_WorldStatic;

	// Token: 0x04000315 RID: 789
	public static readonly ECollisionChannel WorldDynamic = ECollisionChannel.ECC_WorldDynamic;

	// Token: 0x04000316 RID: 790
	public static readonly ECollisionChannel Pawn = ECollisionChannel.ECC_Pawn;

	// Token: 0x04000317 RID: 791
	public static readonly ECollisionChannel Visibility = ECollisionChannel.ECC_Visibility;

	// Token: 0x04000318 RID: 792
	public static readonly ECollisionChannel Camera = ECollisionChannel.ECC_Camera;

	// Token: 0x04000319 RID: 793
	public static readonly ECollisionChannel PhysicsBody = ECollisionChannel.ECC_PhysicsBody;

	// Token: 0x0400031A RID: 794
	public static readonly ECollisionChannel Vehicle = ECollisionChannel.ECC_Vehicle;

	// Token: 0x0400031B RID: 795
	public static readonly ECollisionChannel Destructible = ECollisionChannel.ECC_Destructible;

	// Token: 0x0400031C RID: 796
	public static readonly ECollisionChannel StraightWall_Deprecated = ECollisionChannel.ECC_GameTraceChannel1;

	// Token: 0x0400031D RID: 797
	public static readonly ECollisionChannel Water = ECollisionChannel.ECC_GameTraceChannel2;

	// Token: 0x0400031E RID: 798
	public static readonly ECollisionChannel Climb = ECollisionChannel.ECC_GameTraceChannel3;

	// Token: 0x0400031F RID: 799
	public static readonly ECollisionChannel IkGround = ECollisionChannel.ECC_GameTraceChannel4;

	// Token: 0x04000320 RID: 800
	public static readonly ECollisionChannel PawnPlayer = ECollisionChannel.ECC_GameTraceChannel5;

	// Token: 0x04000321 RID: 801
	public static readonly ECollisionChannel Bullet = ECollisionChannel.ECC_GameTraceChannel6;

	// Token: 0x04000322 RID: 802
	public static readonly ECollisionChannel CanBeObserved_Deprecated = ECollisionChannel.ECC_GameTraceChannel7;

	// Token: 0x04000323 RID: 803
	public static readonly ECollisionChannel PawnMonster = ECollisionChannel.ECC_GameTraceChannel8;

	// Token: 0x04000324 RID: 804
	public static readonly ECollisionChannel Lgui = ECollisionChannel.ECC_GameTraceChannel9;

	// Token: 0x04000325 RID: 805
	public static readonly ECollisionChannel WorldStaticIgnoreBullet = ECollisionChannel.ECC_GameTraceChannel10;

	// Token: 0x04000326 RID: 806
	public static readonly ECollisionChannel KuroTrigger = ECollisionChannel.ECC_GameTraceChannel11;

	// Token: 0x04000327 RID: 807
	public static readonly ECollisionChannel AirFloor = ECollisionChannel.ECC_GameTraceChannel12;

	// Token: 0x04000328 RID: 808
	public static readonly ECollisionChannel AcrossBlock = ECollisionChannel.ECC_GameTraceChannel13;

	// Token: 0x04000329 RID: 809
	public static readonly ECollisionChannel VoiceBlock = ECollisionChannel.ECC_GameTraceChannel14;

	// Token: 0x0400032A RID: 810
	public static readonly ECollisionChannel HitItem = ECollisionChannel.ECC_GameTraceChannel15;

	// Token: 0x0400032B RID: 811
	public static readonly ECollisionChannel BulletSpecial = ECollisionChannel.ECC_GameTraceChannel16;

	// Token: 0x0400032C RID: 812
	public static readonly ECollisionChannel KuroWater = ECollisionChannel.ECC_GameTraceChannel18;
}
