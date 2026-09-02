using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Token: 0x02002EA1 RID: 11937
public static class BuffIdUtils
{
	// Token: 0x0601881C RID: 100380 RVA: 0x006DF694 File Offset: 0x006DD894
	public static bool CheckBuffInSpecialList(long checkBuffId)
	{
		if (SpecialIgnoreBuff.Values.Contains(checkBuffId))
		{
			return true;
		}
		if (SpecialIgnoreGaBuff.Values.Contains(checkBuffId))
		{
			return true;
		}
		if (NoBroadCastBuff.Values.Contains(checkBuffId))
		{
			return true;
		}
		if (new long[]
		{
			1900000014L,
			1900000015L,
			1900000017L
		}.Contains(checkBuffId))
		{
			return true;
		}
		using (IEnumerator<long> enumerator = (from f in typeof(BuffId).GetFields()
		where f.IsLiteral && !f.IsInitOnly
		select Convert.ToInt64(f.GetValue(null))).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == checkBuffId)
				{
					return true;
				}
			}
		}
		return false;
	}
}
