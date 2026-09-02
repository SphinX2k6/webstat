using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BE7 RID: 7143
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchToyDataComponent)]
public class FloroRanchToyDataComponent : FloroRanchEntityDataBaseComponent
{
	// Token: 0x0600CFBC RID: 53180 RVA: 0x00372B78 File Offset: 0x00370D78
	public override void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		if (entityData.Type != FloroRanchActionUnitType.Toy)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchToyDataComponent刷新数据类型错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityType", entityData.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FloroRanchToyData floroRanchToyData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyData(entityData.Id);
		this.ToyData = floroRanchToyData;
		this.Level = (int)Singleton<MathUtils>.Instance.LongToBigInt(entityData.ToyLv);
	}

	// Token: 0x0600CFBD RID: 53181 RVA: 0x00372BF2 File Offset: 0x00370DF2
	public void RefreshLevel(int level)
	{
		this.Level = level;
	}

	// Token: 0x0600CFBE RID: 53182 RVA: 0x00372BFB File Offset: 0x00370DFB
	public override string Info()
	{
		return "Name:" + this.ToyData.Name;
	}

	// Token: 0x0600CFBF RID: 53183 RVA: 0x00372C14 File Offset: 0x00370E14
	public override string DebugInfo()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ToyData.Id);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(this.ToyData.Name);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x040062EE RID: 25326
	[Nullable(2)]
	public FloroRanchToyData ToyData;

	// Token: 0x040062EF RID: 25327
	public int Level;
}
