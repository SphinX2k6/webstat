using System;
using System.Runtime.CompilerServices;

// Token: 0x020026EE RID: 9966
[NullableContext(1)]
[Nullable(0)]
public readonly struct ERacingBetsAudioState : IEquatable<ERacingBetsAudioState>
{
	// Token: 0x06013AE8 RID: 80616 RVA: 0x0057D1DA File Offset: 0x0057B3DA
	private ERacingBetsAudioState(string value)
	{
		this._Value = value;
	}

	// Token: 0x06013AE9 RID: 80617 RVA: 0x0057D1E3 File Offset: 0x0057B3E3
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x06013AEA RID: 80618 RVA: 0x0057D1EB File Offset: 0x0057B3EB
	public bool Equals(ERacingBetsAudioState other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x06013AEB RID: 80619 RVA: 0x0057D200 File Offset: 0x0057B400
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ERacingBetsAudioState)
		{
			ERacingBetsAudioState other = (ERacingBetsAudioState)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06013AEC RID: 80620 RVA: 0x0057D225 File Offset: 0x0057B425
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06013AED RID: 80621 RVA: 0x0057D238 File Offset: 0x0057B438
	public static bool operator ==(ERacingBetsAudioState left, ERacingBetsAudioState right)
	{
		return left.Equals(right);
	}

	// Token: 0x06013AEE RID: 80622 RVA: 0x0057D242 File Offset: 0x0057B442
	public static bool operator !=(ERacingBetsAudioState left, ERacingBetsAudioState right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04009920 RID: 39200
	private readonly string _Value;

	// Token: 0x04009921 RID: 39201
	public static readonly ERacingBetsAudioState None = new ERacingBetsAudioState("none");

	// Token: 0x04009922 RID: 39202
	public static readonly ERacingBetsAudioState RaceGroupStage = new ERacingBetsAudioState("race_groupstage");

	// Token: 0x04009923 RID: 39203
	public static readonly ERacingBetsAudioState RaceFinals = new ERacingBetsAudioState("race_finals");

	// Token: 0x04009924 RID: 39204
	public static readonly ERacingBetsAudioState RaceMatchPoint = new ERacingBetsAudioState("race_matchpoint");

	// Token: 0x04009925 RID: 39205
	public static readonly ERacingBetsAudioState Complete = new ERacingBetsAudioState("complete");
}
