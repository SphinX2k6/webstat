using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BDF RID: 7135
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchCardDataComponent)]
public class FloroRanchCardDataComponent : FloroRanchEntityDataBaseComponent
{
	// Token: 0x0600CF8A RID: 53130 RVA: 0x00372030 File Offset: 0x00370230
	public override void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		if (entityData.Type != FloroRanchActionUnitType.Phantom)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchCardDataComponent刷新数据类型错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityType", entityData.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FloroRanchCardData floroRanchCardData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardData(entityData.Id);
		this.CardData = floroRanchCardData;
		this.RefreshEvolveData(entityData.EvolveData);
	}

	// Token: 0x0600CF8B RID: 53131 RVA: 0x0037209F File Offset: 0x0037029F
	[NullableContext(2)]
	public void RefreshEvolveData(FREvolveData evolveData)
	{
		if (this.EvolveData == null)
		{
			if (evolveData != null)
			{
				this.EvolveData = new FloroRanchEvolveData(evolveData);
				return;
			}
		}
		else
		{
			this.EvolveData.Refresh(evolveData);
		}
	}

	// Token: 0x0600CF8C RID: 53132 RVA: 0x003720C5 File Offset: 0x003702C5
	public bool EvolveDataValid()
	{
		return this.EvolveData != null && this.EvolveData.IsValid;
	}

	// Token: 0x0600CF8D RID: 53133 RVA: 0x003720DC File Offset: 0x003702DC
	public override string Info()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CardData.Id);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(this.CardData.Name);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600CF8E RID: 53134 RVA: 0x0037212C File Offset: 0x0037032C
	public override string DebugInfo()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CardData.Id);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(this.CardData.Name);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x040062D5 RID: 25301
	[Nullable(2)]
	public FloroRanchCardData CardData;

	// Token: 0x040062D6 RID: 25302
	[Nullable(2)]
	public FloroRanchEvolveData EvolveData;
}
