using System;

namespace UnrealEngine
{
	// Token: 0x020043DC RID: 17372
	public static class GameplayTagExtensions
	{
		// Token: 0x0602E281 RID: 189057 RVA: 0x00ADADFD File Offset: 0x00AD8FFD
		public static int TagId(this FGameplayTag tag)
		{
			return GameplayTagCache.GetOrCreateTagId(tag.TagName);
		}

		// Token: 0x0602E282 RID: 189058 RVA: 0x00ADAE0A File Offset: 0x00AD900A
		public static FName OriginalTagName(this FGameplayTag tag)
		{
			return GameplayTagCache.GetOrCreateOriginalTagName(tag.TagName);
		}
	}
}
