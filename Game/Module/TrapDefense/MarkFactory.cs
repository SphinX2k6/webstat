using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB2 RID: 19890
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkFactory
	{
		// Token: 0x0603385B RID: 211035 RVA: 0x00CE34CA File Offset: 0x00CE16CA
		public static TrapMapEntity CreateAndAssembleMark(ITrapDefenseMarkInfo param)
		{
			TrapMapEntity trapMapEntity = MarkFactory.CreateDefaultEntity(param);
			MarkFactory.AssembleMarkComponents(trapMapEntity, param);
			return trapMapEntity;
		}

		// Token: 0x0603385C RID: 211036 RVA: 0x00CE34DC File Offset: 0x00CE16DC
		private static void AssembleMarkComponents(TrapMapEntity entity, ITrapDefenseMarkInfo param)
		{
			ETrapDefenseMapComponent[] array;
			if (TrapDefenseDefine.markAssembleRegisterMap.TryGetValue(param.MarkType, out array))
			{
				foreach (ETrapDefenseMapComponent componentType in array)
				{
					entity.AddComponent<TrapMapComponentBase>(componentType);
				}
			}
		}

		// Token: 0x0603385D RID: 211037 RVA: 0x00CE3519 File Offset: 0x00CE1719
		private static TrapMapEntity CreateDefaultEntity(ITrapDefenseMarkInfo param)
		{
			return new TrapMapEntity();
		}
	}
}
