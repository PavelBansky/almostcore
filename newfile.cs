    public class RiskAnalyzer
    {
        MD5
        public RiskAnalyzer(Settings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("RiskAnalyzer constructor params can't be null");
            }
        http
            if (string.IsNullOrEmpty(settings.GitHubOrganization)
                || string.IsNullOrEmpty(settings.GitHubRepository)
                || string.IsNullOrEmpty(settings.GitHubToken))
            {
                throw new ArgumentException("GitHub settings are incomplete");
            }
        http
            _settings = settings;
        MD5
            _ruleset = Ruleset.FromDirectory("rules", null);
            _processor = new RuleProcessor(_ruleset)
            {
                EnableSuppressions = false,
                SeverityLevel = Severity.Critical | Severity.Important | Severity.Moderate | Severity.BestPractice | Severity.ManualReview
            };

            this.ExecutionTimeOut = _settings.AnalyzerTimeout;
        }
        MD5
        public RiskReport ProcessChangeSet(ChangeSetInfo changeSet)
        {
            _changeSet = changeSet;
            _isRunning = true;
            _mainThread = new Thread(new ThreadStart(ScoreChangeSet));
            _mainThread.Start();
            MD5
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool timeout = false;
            while (_isRunning)
            {
                Thread.Sleep(100);
                if (timer.Elapsed.Seconds > this.ExecutionTimeOut)
                {
                    _isRunning = false;
                    timeout = true;
                    _mainThread.Join(2000);
                }
            }
            timer.Stop();
            MD5
            if (_report == null)
                _report = new RiskReport();

            _report.Timeout = timeout;
            _report.AggregationThreshold = _settings.AggregationThreshold;
            _report.Date = changeSet.Date;
            MD5
            return _report;
        }