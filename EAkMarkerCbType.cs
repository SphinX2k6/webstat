using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x0200001F RID: 31
[NullableContext(1)]
[Nullable(0)]
public class EAkMarkerCbType : IEquatable<EAkMarkerCbType>
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000083 RID: 131 RVA: 0x000056B8 File Offset: 0x000038B8
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(EAkMarkerCbType);
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000056C4 File Offset: 0x000038C4
	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("EAkMarkerCbType");
		stringBuilder.Append(" { ");
		if (this.PrintMembers(stringBuilder))
		{
			stringBuilder.Append(' ');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00005710 File Offset: 0x00003910
	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		return false;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00005713 File Offset: 0x00003913
	[NullableContext(2)]
	[CompilerGenerated]
	public static bool operator !=(EAkMarkerCbType left, EAkMarkerCbType right)
	{
		return !(left == right);
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000571F File Offset: 0x0000391F
	[NullableContext(2)]
	[CompilerGenerated]
	public static bool operator ==(EAkMarkerCbType left, EAkMarkerCbType right)
	{
		return left == right || (left != null && left.Equals(right));
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00005733 File Offset: 0x00003933
	[CompilerGenerated]
	public override int GetHashCode()
	{
		return EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract);
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00005745 File Offset: 0x00003945
	[NullableContext(2)]
	[CompilerGenerated]
	public override bool Equals(object obj)
	{
		return this.Equals(obj as EAkMarkerCbType);
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00005753 File Offset: 0x00003953
	[NullableContext(2)]
	[CompilerGenerated]
	public virtual bool Equals(EAkMarkerCbType other)
	{
		return this == other || (other != null && this.EqualityContract == other.EqualityContract);
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00005779 File Offset: 0x00003979
	[CompilerGenerated]
	protected EAkMarkerCbType(EAkMarkerCbType original)
	{
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00005781 File Offset: 0x00003981
	public EAkMarkerCbType()
	{
	}

	// Token: 0x0400006B RID: 107
	public const string SoundTrackEffect = "SoundTrackingEffectNotify";
}
