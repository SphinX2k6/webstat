using System;
using System.Runtime.CompilerServices;

// Token: 0x020018D6 RID: 6358
public class FeatureRestrictionTemplate : IStaticVariableResetter
{
	// Token: 0x0600B6D0 RID: 46800 RVA: 0x00309CCF File Offset: 0x00307ECF
	static FeatureRestrictionTemplate()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FeatureRestrictionTemplate.CreateStaticDefaultValue), new Action(FeatureRestrictionTemplate.ResetStaticDefaultValue));
	}

	// Token: 0x0600B6D1 RID: 46801 RVA: 0x00309CEE File Offset: 0x00307EEE
	private FeatureRestrictionTemplate(EFeatureParseMode parseMode, EForceMode forceMode = EForceMode.None)
	{
		this.ParseMode = parseMode;
		this.ForceMode = forceMode;
	}

	// Token: 0x0600B6D2 RID: 46802 RVA: 0x00309D0B File Offset: 0x00307F0B
	private void AddClientMask(EClientFeature mask)
	{
		this.ClientFeatureMasks |= (int)mask;
	}

	// Token: 0x0600B6D3 RID: 46803 RVA: 0x00309D1B File Offset: 0x00307F1B
	private bool CheckByMask(int current, int mask)
	{
		return (current & mask) == mask;
	}

	// Token: 0x0600B6D4 RID: 46804 RVA: 0x00309D24 File Offset: 0x00307F24
	private int ParseCurrentClient()
	{
		int num = 0;
		CommonConfig instance = ConfigBase<CommonConfig>.Instance;
		if (instance != null && instance.GetPioneerFlag().GetValueOrDefault())
		{
			num |= 8;
		}
		return num;
	}

	// Token: 0x0600B6D5 RID: 46805 RVA: 0x00309D53 File Offset: 0x00307F53
	private int ParseCurrentServer()
	{
		return 0 | 0;
	}

	// Token: 0x0600B6D6 RID: 46806 RVA: 0x00309D58 File Offset: 0x00307F58
	public bool Check()
	{
		EForceMode forceMode = this.ForceMode;
		if (forceMode == EForceMode.White)
		{
			return true;
		}
		if (forceMode == EForceMode.Black)
		{
			return false;
		}
		switch (this.ParseMode)
		{
		case EFeatureParseMode.ClientOnly:
			return this.CheckByMask(this.ParseCurrentClient(), this.ClientFeatureMasks);
		case EFeatureParseMode.ServerOnly:
			return this.CheckByMask(this.ParseCurrentServer(), this.ServerFeatureMasks);
		case EFeatureParseMode.All:
			return this.CheckByMask(this.ParseCurrentClient(), this.ClientFeatureMasks) && this.CheckByMask(this.ParseCurrentServer(), this.ServerFeatureMasks);
		default:
			return false;
		}
	}

	// Token: 0x17000EF8 RID: 3832
	// (get) Token: 0x0600B6D7 RID: 46807 RVA: 0x00309DE5 File Offset: 0x00307FE5
	[Nullable(1)]
	public static FeatureRestrictionTemplate TemplateForPioneerClient
	{
		[NullableContext(1)]
		get
		{
			if (FeatureRestrictionTemplate.TemplateForPioneerClientCore != null)
			{
				return FeatureRestrictionTemplate.TemplateForPioneerClientCore;
			}
			FeatureRestrictionTemplate featureRestrictionTemplate = new FeatureRestrictionTemplate(EFeatureParseMode.ClientOnly, EForceMode.None);
			featureRestrictionTemplate.AddClientMask(EClientFeature.Pioneer);
			FeatureRestrictionTemplate.TemplateForPioneerClientCore = featureRestrictionTemplate;
			return featureRestrictionTemplate;
		}
	}

	// Token: 0x0600B6D8 RID: 46808 RVA: 0x00309E08 File Offset: 0x00308008
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0600B6D9 RID: 46809 RVA: 0x00309E0A File Offset: 0x0030800A
	public static void ResetStaticDefaultValue()
	{
		FeatureRestrictionTemplate.TemplateForPioneerClientCore = null;
	}

	// Token: 0x04005636 RID: 22070
	private int ClientFeatureMasks;

	// Token: 0x04005637 RID: 22071
	private readonly int ServerFeatureMasks;

	// Token: 0x04005638 RID: 22072
	private readonly EFeatureParseMode ParseMode = EFeatureParseMode.All;

	// Token: 0x04005639 RID: 22073
	private readonly EForceMode ForceMode;

	// Token: 0x0400563A RID: 22074
	[Nullable(2)]
	private static FeatureRestrictionTemplate TemplateForPioneerClientCore;
}
