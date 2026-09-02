using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E1D RID: 7709
[NullableContext(1)]
[Nullable(0)]
public readonly struct EGuideFocusTextDir : IEquatable<EGuideFocusTextDir>
{
	// Token: 0x0600E38B RID: 58251 RVA: 0x003D4144 File Offset: 0x003D2344
	private EGuideFocusTextDir(string value)
	{
		this._value = value;
	}

	// Token: 0x0600E38C RID: 58252 RVA: 0x003D414D File Offset: 0x003D234D
	public override string ToString()
	{
		return this._value;
	}

	// Token: 0x0600E38D RID: 58253 RVA: 0x003D4155 File Offset: 0x003D2355
	public bool Equals(EGuideFocusTextDir other)
	{
		return this._value == other._value;
	}

	// Token: 0x0600E38E RID: 58254 RVA: 0x003D4168 File Offset: 0x003D2368
	public static implicit operator string(EGuideFocusTextDir name)
	{
		return name._value;
	}

	// Token: 0x0600E38F RID: 58255 RVA: 0x003D4170 File Offset: 0x003D2370
	public static explicit operator EGuideFocusTextDir(string value)
	{
		return new EGuideFocusTextDir(value);
	}

	// Token: 0x04006D76 RID: 28022
	private readonly string _value;

	// Token: 0x04006D77 RID: 28023
	public static readonly EGuideFocusTextDir Left = new EGuideFocusTextDir("L");

	// Token: 0x04006D78 RID: 28024
	public static readonly EGuideFocusTextDir Right = new EGuideFocusTextDir("R");

	// Token: 0x04006D79 RID: 28025
	public static readonly EGuideFocusTextDir Up = new EGuideFocusTextDir("U");

	// Token: 0x04006D7A RID: 28026
	public static readonly EGuideFocusTextDir Down = new EGuideFocusTextDir("D");

	// Token: 0x04006D7B RID: 28027
	public static readonly EGuideFocusTextDir CenterTop = new EGuideFocusTextDir("CT");

	// Token: 0x04006D7C RID: 28028
	public static readonly EGuideFocusTextDir Float = new EGuideFocusTextDir("FL");
}
