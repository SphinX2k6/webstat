using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BE6 RID: 7142
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchTerrainDataComponent)]
public class FloroRanchTerrainDataComponent : FloroRanchEntityDataBaseComponent
{
	// Token: 0x0600CFB8 RID: 53176 RVA: 0x00372AE0 File Offset: 0x00370CE0
	public override void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		if (entityData.Type != FloroRanchActionUnitType.Terrain)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchTerrainDataComponent刷新数据类型错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityType", entityData.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FloroRanchTerrainData floroRanchTerrain = ModelBase<FloroRanchModel>.Instance.GetFloroRanchTerrain(entityData.Id);
		this.TerrainData = floroRanchTerrain;
	}

	// Token: 0x0600CFB9 RID: 53177 RVA: 0x00372B42 File Offset: 0x00370D42
	public override string Info()
	{
		return "Name:" + this.TerrainData.Name;
	}

	// Token: 0x0600CFBA RID: 53178 RVA: 0x00372B59 File Offset: 0x00370D59
	public override string DebugInfo()
	{
		return this.TerrainData.Name ?? "";
	}

	// Token: 0x040062ED RID: 25325
	[Nullable(2)]
	public FloroRanchTerrainData TerrainData;
}
