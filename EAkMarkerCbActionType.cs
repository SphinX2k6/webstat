using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x02000020 RID: 32
[NullableContext(1)]
[Nullable(0)]
public class EAkMarkerCbActionType : IEquatable<EAkMarkerCbActionType>
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600008E RID: 142 RVA: 0x00005789 File Offset: 0x00003989
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(EAkMarkerCbActionType);
		}
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00005798 File Offset: 0x00003998
	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("EAkMarkerCbActionType");
		stringBuilder.Append(" { ");
		if (this.PrintMembers(stringBuilder))
		{
			stringBuilder.Append(' ');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000057E4 File Offset: 0x000039E4
	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		return false;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x000057E7 File Offset: 0x000039E7
	[NullableContext(2)]
	[CompilerGenerated]
	public static bool operator !=(EAkMarkerCbActionType left, EAkMarkerCbActionType right)
	{
		return !(left == right);
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000057F3 File Offset: 0x000039F3
	[NullableContext(2)]
	[CompilerGenerated]
	public static bool operator ==(EAkMarkerCbActionType left, EAkMarkerCbActionType right)
	{
		return left == right || (left != null && left.Equals(right));
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00005807 File Offset: 0x00003A07
	[CompilerGenerated]
	public override int GetHashCode()
	{
		return EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract);
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00005819 File Offset: 0x00003A19
	[NullableContext(2)]
	[CompilerGenerated]
	public override bool Equals(object obj)
	{
		return this.Equals(obj as EAkMarkerCbActionType);
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00005827 File Offset: 0x00003A27
	[NullableContext(2)]
	[CompilerGenerated]
	public virtual bool Equals(EAkMarkerCbActionType other)
	{
		return this == other || (other != null && this.EqualityContract == other.EqualityContract);
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000584D File Offset: 0x00003A4D
	[CompilerGenerated]
	protected EAkMarkerCbActionType(EAkMarkerCbActionType original)
	{
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00005855 File Offset: 0x00003A55
	public EAkMarkerCbActionType()
	{
	}

	// Token: 0x0400006C RID: 108
	public const string Start = "Start";

	// Token: 0x0400006D RID: 109
	public const string End = "End";
}
