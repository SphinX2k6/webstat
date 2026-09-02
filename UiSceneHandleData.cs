using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C5F RID: 11359
[NullableContext(1)]
[Nullable(0)]
public class UiSceneHandleData
{
	// Token: 0x06016CCB RID: 93387 RVA: 0x00652E03 File Offset: 0x00651003
	public UiSceneHandleData()
	{
		this.CustomPromise = new CustomPromise<bool>();
	}

	// Token: 0x06016CCC RID: 93388 RVA: 0x00652E16 File Offset: 0x00651016
	public void SetSequence(UiCameraSequence sequence)
	{
		this.Sequence = sequence;
	}

	// Token: 0x06016CCD RID: 93389 RVA: 0x00652E1F File Offset: 0x0065101F
	public void DestroyUiCameraSequence()
	{
		UiCameraSequence sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.DestroyUiCameraSequence(true);
		}
		this.Sequence = null;
	}

	// Token: 0x0400AFA3 RID: 44963
	public CustomPromise<bool> CustomPromise;

	// Token: 0x0400AFA4 RID: 44964
	[Nullable(2)]
	private UiCameraSequence Sequence;
}
