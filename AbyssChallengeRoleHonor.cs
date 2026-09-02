using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABC RID: 6844
public class AbyssChallengeRoleHonor
{
	// Token: 0x0600C492 RID: 50322 RVA: 0x0033E090 File Offset: 0x0033C290
	public new int GetType()
	{
		return this.Type;
	}

	// Token: 0x0600C493 RID: 50323 RVA: 0x0033E098 File Offset: 0x0033C298
	public int GetValue()
	{
		return this.Value;
	}

	// Token: 0x0600C494 RID: 50324 RVA: 0x0033E0A0 File Offset: 0x0033C2A0
	[NullableContext(2)]
	public void Phrase(Aki.Protocol.AbyssChallengeRoleHonor data)
	{
		if (data == null)
		{
			return;
		}
		this.Type = data.Type;
		this.Value = data.Value;
	}

	// Token: 0x04005E47 RID: 24135
	private int Type;

	// Token: 0x04005E48 RID: 24136
	private int Value;
}
