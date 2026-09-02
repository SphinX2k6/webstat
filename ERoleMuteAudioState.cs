using System;
using System.Runtime.CompilerServices;

// Token: 0x020027D5 RID: 10197
[NullableContext(1)]
[Nullable(0)]
public readonly struct ERoleMuteAudioState : IEquatable<ERoleMuteAudioState>
{
	// Token: 0x06014280 RID: 82560 RVA: 0x005A053A File Offset: 0x0059E73A
	private ERoleMuteAudioState(string value)
	{
		this._value = value;
	}

	// Token: 0x06014281 RID: 82561 RVA: 0x005A0543 File Offset: 0x0059E743
	public override string ToString()
	{
		return this._value;
	}

	// Token: 0x06014282 RID: 82562 RVA: 0x005A054B File Offset: 0x0059E74B
	public bool Equals(ERoleMuteAudioState other)
	{
		return this._value == other._value;
	}

	// Token: 0x06014283 RID: 82563 RVA: 0x005A0560 File Offset: 0x0059E760
	[NullableContext(2)]
	public override bool Equals(object obj)
	{
		if (obj is ERoleMuteAudioState)
		{
			ERoleMuteAudioState other = (ERoleMuteAudioState)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x06014284 RID: 82564 RVA: 0x005A0585 File Offset: 0x0059E785
	public override int GetHashCode()
	{
		string value = this._value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x06014285 RID: 82565 RVA: 0x005A0598 File Offset: 0x0059E798
	public static bool operator ==(ERoleMuteAudioState? left, ERoleMuteAudioState? right)
	{
		return left.Equals(right);
	}

	// Token: 0x06014286 RID: 82566 RVA: 0x005A05AD File Offset: 0x0059E7AD
	public static bool operator !=(ERoleMuteAudioState? left, ERoleMuteAudioState? right)
	{
		return !left.Equals(right);
	}

	// Token: 0x06014287 RID: 82567 RVA: 0x005A05C5 File Offset: 0x0059E7C5
	public static implicit operator string(ERoleMuteAudioState state)
	{
		return state.ToString();
	}

	// Token: 0x04009CE0 RID: 40160
	private readonly string _value;

	// Token: 0x04009CE1 RID: 40161
	public static readonly ERoleMuteAudioState None = new ERoleMuteAudioState("none");

	// Token: 0x04009CE2 RID: 40162
	public static readonly ERoleMuteAudioState Mute = new ERoleMuteAudioState("mute");
}
