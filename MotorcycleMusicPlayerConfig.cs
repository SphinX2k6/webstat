using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200230B RID: 8971
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MotorcycleMusicPlayerConfig : ConfigBase<MotorcycleMusicPlayerConfig>
{
	// Token: 0x060110A9 RID: 69801 RVA: 0x004ADBB4 File Offset: 0x004ABDB4
	public int GetFavoriteAlbumId()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomMusicCollectAlbum").Value;
	}

	// Token: 0x060110AA RID: 69802 RVA: 0x004ADBD4 File Offset: 0x004ABDD4
	public int GetDefaultAlbumId()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomMusicDefaultAlbum").Value;
	}

	// Token: 0x060110AB RID: 69803 RVA: 0x004ADBF4 File Offset: 0x004ABDF4
	public int GetFavoriteCountLimit()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomMusicCollectMaxCount").Value;
	}

	// Token: 0x060110AC RID: 69804 RVA: 0x004ADC14 File Offset: 0x004ABE14
	public float GetAlbumVelocity()
	{
		return ConfigCommonParamById.GetFloatConfig("MotorMusicUIVelocity").GetValueOrDefault(1f);
	}

	// Token: 0x060110AD RID: 69805 RVA: 0x004ADC38 File Offset: 0x004ABE38
	public float GetDragSwapSpeed()
	{
		return ConfigCommonParamById.GetFloatConfig("MotorMusicDragSwapSpeed").GetValueOrDefault(10f);
	}

	// Token: 0x060110AE RID: 69806 RVA: 0x004ADC5C File Offset: 0x004ABE5C
	[NullableContext(0)]
	public ValueTuple<float, float> GetDragScrollSpeedRange()
	{
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("MotorMusicSortScrollSpeedRange");
		if (floatArrayConfig != null && floatArrayConfig.Count >= 2)
		{
			return new ValueTuple<float, float>(floatArrayConfig[0], floatArrayConfig[1]);
		}
		return new ValueTuple<float, float>(0.001f, 0.01f);
	}

	// Token: 0x060110AF RID: 69807 RVA: 0x004ADCA4 File Offset: 0x004ABEA4
	public int GetStartDelay()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicStartDelay").GetValueOrDefault(1f) * 1000f));
	}

	// Token: 0x060110B0 RID: 69808 RVA: 0x004ADCD8 File Offset: 0x004ABED8
	public int GetFadeInTime()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicStartFadein").GetValueOrDefault(1f) * 1000f));
	}

	// Token: 0x060110B1 RID: 69809 RVA: 0x004ADD0C File Offset: 0x004ABF0C
	public int GetFadeOutTime()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicStartFadeout").GetValueOrDefault(1f) * 1000f));
	}

	// Token: 0x060110B2 RID: 69810 RVA: 0x004ADD40 File Offset: 0x004ABF40
	public int GetMusicUnlockTipTime()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicUnlockTipTime").GetValueOrDefault(3f) * 1000f));
	}

	// Token: 0x060110B3 RID: 69811 RVA: 0x004ADD74 File Offset: 0x004ABF74
	public int GetRestartFadeInTime()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicRestartFadein").GetValueOrDefault(1f) * 1000f));
	}

	// Token: 0x060110B4 RID: 69812 RVA: 0x004ADDA8 File Offset: 0x004ABFA8
	public int GetInterruptFadeOutTime()
	{
		return (int)Math.Round((double)(ConfigCommonParamById.GetFloatConfig("MotorMusicInterruptFadeout").GetValueOrDefault(1f) * 1000f));
	}

	// Token: 0x060110B5 RID: 69813 RVA: 0x004ADDD9 File Offset: 0x004ABFD9
	public string GetScaleCurvePath()
	{
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("AlbumScaleCurve");
	}

	// Token: 0x060110B6 RID: 69814 RVA: 0x004ADDEA File Offset: 0x004ABFEA
	public string GetAlphaCurvePath()
	{
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("AlbumAlphaCurve");
	}

	// Token: 0x060110B7 RID: 69815 RVA: 0x004ADDFB File Offset: 0x004ABFFB
	public string GetRotateCurvePath()
	{
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("AlbumRotateCurve");
	}
}
