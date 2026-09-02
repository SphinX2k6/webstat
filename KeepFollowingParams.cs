using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030DA RID: 12506
[NullableContext(1)]
[Nullable(0)]
public class KeepFollowingParams
{
	// Token: 0x06019CCC RID: 105676 RVA: 0x00788574 File Offset: 0x00786774
	public KeepFollowingParams(CharacterActorComponent leader, EHandType? handType = null)
	{
		this.Leader = leader;
		this.HandType = handType;
	}

	// Token: 0x06019CCD RID: 105677 RVA: 0x0078858A File Offset: 0x0078678A
	public void InitWithDataAsset(BP_KeepFollowingConfig_C data)
	{
		this.DebugDraw = data.DebugDraw;
		this.MoveParamsInternal = new FollowingMoveParams(data);
		this.RotatorParamsInternal = new FollowingRotatorParams(data);
	}

	// Token: 0x06019CCE RID: 105678 RVA: 0x007885B0 File Offset: 0x007867B0
	public void InitWithParams(FollowingMoveParams moveParams, FollowingRotatorParams rotParams, bool? debug = null)
	{
		this.DebugDraw = debug.GetValueOrDefault();
		this.MoveParamsInternal = moveParams;
		this.RotatorParamsInternal = rotParams;
	}

	// Token: 0x170022D8 RID: 8920
	// (get) Token: 0x06019CCF RID: 105679 RVA: 0x007885CD File Offset: 0x007867CD
	public FollowingMoveParams MoveParams
	{
		get
		{
			if (this.MoveParamsInternal == null)
			{
				this.MoveParamsInternal = new FollowingMoveParams(null);
			}
			return this.MoveParamsInternal;
		}
	}

	// Token: 0x170022D9 RID: 8921
	// (get) Token: 0x06019CD0 RID: 105680 RVA: 0x007885E9 File Offset: 0x007867E9
	public FollowingRotatorParams RotatorParams
	{
		get
		{
			if (this.RotatorParamsInternal == null)
			{
				this.RotatorParamsInternal = new FollowingRotatorParams(null);
			}
			return this.RotatorParamsInternal;
		}
	}

	// Token: 0x0400CE5E RID: 52830
	public bool DebugDraw;

	// Token: 0x0400CE5F RID: 52831
	[Nullable(2)]
	public CharacterActorComponent Leader;

	// Token: 0x0400CE60 RID: 52832
	public EHandType? HandType;

	// Token: 0x0400CE61 RID: 52833
	public bool FollowingOnce;

	// Token: 0x0400CE62 RID: 52834
	[Nullable(2)]
	public Action<ELevelEventState> Callback;

	// Token: 0x0400CE63 RID: 52835
	[Nullable(2)]
	private FollowingMoveParams MoveParamsInternal;

	// Token: 0x0400CE64 RID: 52836
	[Nullable(2)]
	private FollowingRotatorParams RotatorParamsInternal;
}
