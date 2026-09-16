using System;

public class WorkExperience : ICloneable
{
    public string WorkDate { get; set; }

    public string CompanyName { get; set; }

    public Object Clone()
    {
        return (Object)this.MemberwiseClone();
    }
}

public class Resume : ICloneable
{
    private string _name;

    private int _age;

    private WorkExperience _workExperience;

    public Resume(WorkExperience workExperience)
    {
        _workExperience = (WorkExperience)workExperience.Clone();
    }

    public void SetBaseInformation(string name, int age)
    {
        _name = name;
        _age = age;
    }
    
    public void SetWorkExperience(string workDate, string companyName)
    {
        _workExperience.WorkDate = workDate;
        _workExperience.CompanyName = companyName;
    }

    public void Show()
    {
        Console.WriteLine($"姓名：{_name}，年龄：{_age}，工作时间：{_workExperience.WorkDate}，在职公司：{_workExperience.CompanyName}");
    }

    public Object Clone()
    {
        Resume resume = new Resume(_workExperience);
        resume.SetBaseInformation(_name, _age);
        return (Object)resume;
    }
}

public class Program
{
    public static void Main()
    {
        WorkExperience workExperience = new WorkExperience();
        workExperience.WorkDate = "2004-3-9 ~ 2006-9-9";
        workExperience.CompanyName = "a公司";

        Resume resume1 = new Resume(workExperience);
        resume1.SetBaseInformation("小明", 28);

        Resume resume2 = (Resume)resume1.Clone();
        resume2.SetWorkExperience("2006-9-9 ~ 2008-9-9", "b公司");

        Resume resume3 = (Resume)resume1.Clone();
        resume3.SetBaseInformation("小王", 30);
        resume3.SetWorkExperience("2002-1-9 ~ 2005-9-9", "c公司");

        resume1.Show();
        resume2.Show();
        resume3.Show();
    }
}