using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CA1 RID: 7329
[NullableContext(1)]
[Nullable(0)]
public class FunctionButtonInfo
{
	// Token: 0x17001140 RID: 4416
	// (get) Token: 0x0600D6D0 RID: 54992 RVA: 0x0039589D File Offset: 0x00393A9D
	// (set) Token: 0x0600D6D1 RID: 54993 RVA: 0x003958A5 File Offset: 0x00393AA5
	public string SpritePath { get; set; }

	// Token: 0x17001141 RID: 4417
	// (get) Token: 0x0600D6D2 RID: 54994 RVA: 0x003958AE File Offset: 0x00393AAE
	// (set) Token: 0x0600D6D3 RID: 54995 RVA: 0x003958B6 File Offset: 0x00393AB6
	public Func<bool> StateFunc { get; set; }

	// Token: 0x17001142 RID: 4418
	// (get) Token: 0x0600D6D4 RID: 54996 RVA: 0x003958BF File Offset: 0x00393ABF
	// (set) Token: 0x0600D6D5 RID: 54997 RVA: 0x003958C7 File Offset: 0x00393AC7
	public Action CallBack { get; set; }

	// Token: 0x0600D6D6 RID: 54998 RVA: 0x003958D0 File Offset: 0x00393AD0
	public FunctionButtonInfo(string spritePath, Func<bool> stateFunc, Action callBack)
	{
		this.SpritePath = spritePath;
		this.StateFunc = stateFunc;
		this.CallBack = callBack;
	}
}
