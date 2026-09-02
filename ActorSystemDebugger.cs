using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnrealEngine;

// Token: 0x02000019 RID: 25
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActorSystemDebugger : Singleton<ActorSystemDebugger>
{
	// Token: 0x06000046 RID: 70 RVA: 0x0000389D File Offset: 0x00001A9D
	public void RecordGetPut(GetPutRecord record)
	{
		if (this.EnableDebugger)
		{
			this.AllGetRecord.Add(record);
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000038B4 File Offset: 0x00001AB4
	[NullableContext(2)]
	public void OutPutCsv(string getRecordPath)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("类名,操作类型,是否命中,时间戳,此类型总数,命中率,池中总量,待销毁数量");
		for (int i = 0; i < this.AllGetRecord.Count; i++)
		{
			GetPutRecord getPutRecord = this.AllGetRecord[i];
			string text = getPutRecord.TimeStamp.ToString();
			if (text.Length > 5)
			{
				text = text.Substring(5);
			}
			stringBuilder.Append(getPutRecord.ClassName).Append(',').Append(getPutRecord.GetOrPut).Append(',').Append(getPutRecord.Hit).Append(',').Append(text).Append(',').Append(getPutRecord.ThisTypeTotal).Append(',').Append(getPutRecord.HitRate).Append(',').Append(getPutRecord.CurrentTotal).Append(',').Append(getPutRecord.PendingKillNum).AppendLine();
		}
		string saveText = stringBuilder.ToString();
		if (!string.IsNullOrEmpty(getRecordPath))
		{
			UKuroStaticLibrary.SaveStringToFile(saveText, getRecordPath, false);
			return;
		}
		UKuroStaticLibrary.SaveStringToFile(saveText, this.GetRecordPath, false);
	}

	// Token: 0x04000035 RID: 53
	private readonly string GetRecordPath = "f:/full_get_put_actor.csv";

	// Token: 0x04000036 RID: 54
	private readonly bool EnableDebugger;

	// Token: 0x04000037 RID: 55
	private readonly List<GetPutRecord> AllGetRecord = new List<GetPutRecord>();
}
