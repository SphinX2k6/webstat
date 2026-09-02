using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E56 RID: 28246
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemInspectEffectDefine
	{
		// Token: 0x060448F0 RID: 280816 RVA: 0x011D2FCB File Offset: 0x011D11CB
		public void Init(Func<ItemInspectEffectBase> effectClass, bool repeatable)
		{
			this.EffectClass = effectClass;
			this.Repeatable = repeatable;
		}

		// Token: 0x060448F1 RID: 280817 RVA: 0x011D2FDB File Offset: 0x011D11DB
		public ItemInspectEffectBase GetEffect()
		{
			return this.EffectClass();
		}

		// Token: 0x060448F2 RID: 280818 RVA: 0x011D2FE8 File Offset: 0x011D11E8
		public bool IsRepeatable()
		{
			return this.Repeatable;
		}

		// Token: 0x040262AB RID: 156331
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<ItemInspectEffectBase> EffectClass;

		// Token: 0x040262AC RID: 156332
		private bool Repeatable;
	}
}
